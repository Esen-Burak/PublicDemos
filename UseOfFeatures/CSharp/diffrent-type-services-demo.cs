public interface IService
{
    void SomeMethod();
}

// Örnek bir servis sınıfı
public class MyService : IService
{
    public void SomeMethod()
    {
        Console.WriteLine("Some method called.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Servislerin tanımlandığı IServiceCollection
        IServiceCollection services = new ServiceCollection();

        // AddTransient: Her çağrı için yeni bir örnek oluşturur
        // Her bir IService talebi için yeni bir MyService örneği oluşturulur
        // Her talep için yeni bir nesne istendiğinde, servis her seferinde yeniden oluşturulur
        // Uygulama her talep için farklı bir MyService örneği alır
        services.AddTransient<IService, MyService>();

        // AddSingleton: Uygulama yaşam döngüsü boyunca tek bir örnek oluşturur
        // Uygulama başlatıldığında bir kez MyService örneği oluşturulur ve tüm talepler boyunca aynı örnek kullanılır
        // Tüm talepler, aynı MyService örneğini paylaşır
        services.AddSingleton<IService, MyService>();

        // AddScoped: Her talep için tek bir örnek oluşturur ve talep tamamlandığında atılır
        // Her HTTP isteği için yeni bir MyService örneği oluşturulur ve aynı isteğin tüm parçaları boyunca kullanılır
        // İsteğin kapsamı içinde (scope), tüm talepler, aynı MyService örneğini paylaşır
        services.AddScoped<IService, MyService>();

        // Servisleri oluşturmak için bir ServiceProvider oluşturun
        IServiceProvider serviceProvider = services.BuildServiceProvider();

        // Servislerden birini alın
        var service = serviceProvider.GetService<IService>();

        // Servis yöntemini çağırın
        service.SomeMethod();
    }
}