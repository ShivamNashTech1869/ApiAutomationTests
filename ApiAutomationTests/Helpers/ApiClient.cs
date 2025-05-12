using RestSharp;
using System;

namespace ApiAutomationTests.Helpers
{
    public class ApiClient
    {
        private readonly RestClient client;

        public ApiClient(string baseUrl)
        {
            client = new RestClient(baseUrl);
        }

        public RestRequest CreateRequest(string endpoint, Method method, object? body = null)
        {
            var request = new RestRequest(endpoint, method);
            request.AddHeader("Content-Type", "application/json");

            if (body != null)
            {
                request.AddJsonBody(body);
            }

            return request;
        }

        public RestResponse SendRequest(RestRequest request)
        {
            return client.Execute(request);
        }
    }
}
