public int RunMultipleAsyncFunctions()
{
    // Define the asynchronous functions
    Func<Task<int>> task1 = () => AsyncFunction1();
    Func<Task<int>> task2 = () => AsyncFunction2();
    Func<Task<int>> task3 = () => AsyncFunction3();

    // Create a list of tasks
    List<Task<int>> tasks = new List<Task<int>>
    {
        task1(),
        task2(),
        task3()
    };

    // Wait for all tasks to complete
    Task<int[]> resultTask = Task.WhenAll(tasks);
    resultTask.Wait();

    // Calculate the sum of all results
    int sum = resultTask.Result.Sum();

    return sum;
}

private async Task<int> AsyncFunction1()
{
    await Task.Delay(1000);
    return 10;
}

private async Task<int> AsyncFunction2()
{
    await Task.Delay(2000);
    return 20;
}

private async Task<int> AsyncFunction3()
{
    await Task.Delay(3000);
    return 30;
}