using ApiAutomationTests.Helpers;
using FluentAssertions;
using Newtonsoft.Json;
using RestSharp;
using TechTalk.SpecFlow;
namespace ApiAutomationTests.StepDefinitions
{
[Binding]
[Scope(Tag = "Feature1")]
public class APISteps1
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
        Logger.LogThreadInfo($"GET {endpoint}");
        var request = apiClient!.CreateRequest(endpoint, Method.Get);
        response = apiClient.SendRequest(request);
        Logger.LogResponse("GET", endpoint, response);
    }

    [When(@"I send a POST request to ""(.*)"" with body:")]
    public void WhenISendAPOSTRequestToWithBody(string endpoint, string body)
    {
        Logger.LogThreadInfo($"POST {endpoint}");
        var request = apiClient!.CreateRequest(endpoint, Method.Post, body);
        response = apiClient.SendRequest(request);
        Logger.LogResponse("POST", endpoint, response);
    }

    [Then(@"the response status code should be (.*)")]
    public void ThenTheResponseStatusCodeShouldBe(int statusCode) =>
        ((int)response!.StatusCode).Should().Be(statusCode);

    [Then(@"the response should contain the user name ""(.*)""")]
    public void ThenTheResponseShouldContainTheUserName(string expectedName)
    {
        var user = JsonConvert.DeserializeObject<UserResponse>(response!.Content!);
        user!.Name.Should().Be(expectedName);
    }
}
}
