using ApiAutomationTests.Helpers;
using FluentAssertions;
using Newtonsoft.Json;
using RestSharp;
using TechTalk.SpecFlow;

namespace ApiAutomationTests.StepDefinitions
{
    [Binding]
    public class APISteps
    {
        private ApiClient? apiClient;
        private RestResponse? response;

        [Given(@"I have a valid API client")]
        public void GivenIHaveAValidApiClient()
        {
            apiClient = new ApiClient("https://jsonplaceholder.typicode.com");
        }

        [When(@"I send a GET request to ""(.*)""")]
        public void WhenISendAGETRequestTo(string endpoint)
        {
            if (apiClient == null) throw new InvalidOperationException("API client is not initialized.");

            var request = apiClient.CreateRequest(endpoint, Method.Get);
            response = apiClient.SendRequest(request);

            LogResponse("GET", endpoint);
        }

        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int statusCode)
        {
            response.Should().NotBeNull("Expected a response but found null.");
            ((int)response!.StatusCode).Should().Be(statusCode);
        }

        [Then(@"the response should contain the user name ""(.*)""")]
        public void ThenTheResponseShouldContainTheUserName(string expectedName)
        {
            if (response == null || string.IsNullOrWhiteSpace(response.Content))
                throw new InvalidOperationException("Response or response content is null.");

            try
            {
                var user = JsonConvert.DeserializeObject<UserResponse>(response.Content!);
                Console.WriteLine("Deserialized User Name: " + user?.Name);
                user.Should().NotBeNull("Deserialization returned null.");
                user!.Name.Should().Be(expectedName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to deserialize user: " + ex.Message);
                throw;
            }
        }

        [When(@"I send a POST request to ""(.*)"" with body:")]
        public void WhenISendAPOSTRequestToWithBody(string endpoint, string body)
        {
            if (apiClient == null) throw new InvalidOperationException("API client is not initialized.");

            var request = apiClient.CreateRequest(endpoint, Method.Post, body);
            response = apiClient.SendRequest(request);

            LogResponse("POST", endpoint);
        }

        [When(@"I send a PUT request to ""(.*)"" with body:")]
        public void WhenISendAPUTRequestToWithBody(string endpoint, string body)
        {
            if (apiClient == null) throw new InvalidOperationException("API client is not initialized.");

            var request = apiClient.CreateRequest(endpoint, Method.Put, body);
            response = apiClient.SendRequest(request);

            LogResponse("PUT", endpoint);
        }

        [When(@"I send a DELETE request to ""(.*)""")]
        public void WhenISendADELETERequestTo(string endpoint)
        {
            if (apiClient == null) throw new InvalidOperationException("API client is not initialized.");

            var request = apiClient.CreateRequest(endpoint, Method.Delete);
            response = apiClient.SendRequest(request);

            LogResponse("DELETE", endpoint);
        }

        private void LogResponse(string method, string endpoint)
        {
            Console.WriteLine($"\n[{method} Request]");
            Console.WriteLine($"Endpoint: {endpoint}");
            Console.WriteLine($"Status Code: {(response != null ? response.StatusCode.ToString() : "No response")}");
            Console.WriteLine($"Content: {response?.Content ?? "No content"}\n");
        }
    }
}
