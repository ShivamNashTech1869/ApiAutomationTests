using RestSharp;

namespace ApiAutomationTests.Helpers
{
    public static class Logger
    {
        public static void LogThreadInfo(string stepName)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Thread {Thread.CurrentThread.ManagedThreadId} - {stepName}");
        }

        public static void LogResponse(string method, string endpoint, RestResponse? response)
        {
            Console.WriteLine($"\n[{method} Request]");
            Console.WriteLine($"Endpoint: {endpoint}");
            Console.WriteLine($"Status Code: {(response != null ? response.StatusCode.ToString() : "No response")}");
            Console.WriteLine($"Content: {response?.Content ?? "No content"}\n");
        }
    }
}
