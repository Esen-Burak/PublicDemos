using System;
using System.IO;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Castle.DynamicProxy;

public class HttpResponseLoggingAspect : IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        if (invocation.Method.Name == "postDownloadFile")
        {
            invocation.Proceed();

            var controllerResult = invocation.ReturnValue as IActionResult;

            if (controllerResult != null)
            {
                var objectResult = controllerResult as ObjectResult;

                if (objectResult != null)
                {
                    Console.WriteLine($"Status Code: {objectResult.StatusCode}");
                }
            }
        }
        else
        {
            invocation.Proceed();
        }
    }
}

[ApiController]
[Route("api/[controller]")]
public class FileController : ControllerBase
{
    [HttpPost, Route("Download-File")]
    [Authorize(Roles = "Master,Admin,Analyst")]
    public IActionResult postDownloadFile([FromBody] FileProperty file)
    {
        var folderName = Path.Combine("tmpfiles");
        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        var downloadFile = Path.Combine(pathToSave, file.FullName);

        string contentType = GetMimeType(downloadFile);

        var stream = new FileStream(downloadFile, FileMode.Open);

        if (stream.Length > 0)
        {
            return File(stream, contentType);
        }
        else
        {
            return null;
        }
    }
}

public class FileControllerProxy : ProxyGenerator
{
    public T CreateIntercepted<T>()
    {
        var generator = new ProxyGenerator();
        return generator.CreateInterfaceProxyWithoutTarget<T>(new ProxyGenerationOptions(), new HttpResponseLoggingAspect());
    }
}

class Program
{
    static void Main(string[] args)
    {
        var fileControllerProxy = new FileControllerProxy();
        var fileController = fileControllerProxy.CreateIntercepted<FileController>();

        // Call the controller method here

        Console.ReadKey();
    }
}