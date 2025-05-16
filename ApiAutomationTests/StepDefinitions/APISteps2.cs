using ApiAutomationTests.Helpers;
using FluentAssertions;
using Newtonsoft.Json;
using RestSharp;
using TechTalk.SpecFlow;

namespace ApiAutomationTests.StepDefinitions
{
[Binding]
[Scope(Tag = "Feature2")]
public class APISteps2
{
    private ApiClient? apiClient;
    private RestResponse? response;

    [Given(@"I have a valid API client")]
    public void GivenIHaveAValidApiClient()
    {
        apiClient = new ApiClient("https://jsonplaceholder.typicode.com");
    }

    [When(@"I send a PUT request to ""(.*)"" with body:")]
    public void WhenISendAPUTRequestToWithBody(string endpoint, string body)
    {
        Logger.LogThreadInfo($"PUT {endpoint}");
        var request = apiClient!.CreateRequest(endpoint, Method.Put, body);
        response = apiClient.SendRequest(request);
        Logger.LogResponse("PUT", endpoint, response);
    }

    [When(@"I send a DELETE request to ""(.*)""")]
    public void WhenISendADELETERequestTo(string endpoint)
    {
        Logger.LogThreadInfo($"DELETE {endpoint}");
        var request = apiClient!.CreateRequest(endpoint, Method.Delete);
        response = apiClient.SendRequest(request);
        Logger.LogResponse("DELETE", endpoint, response);
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
