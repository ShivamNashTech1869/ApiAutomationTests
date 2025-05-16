using TechTalk.SpecFlow;

[Binding]
public sealed class Hooks
{
    private readonly ScenarioContext scenarioContext;

    public Hooks(ScenarioContext scenarioContext)
    {
        this.scenarioContext = scenarioContext;
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        Console.WriteLine("Starting Scenario: " + scenarioContext.ScenarioInfo.Title);
    }

    [AfterScenario]
    public void AfterScenario()
    {
        Console.WriteLine("Finished Scenario: " + scenarioContext.ScenarioInfo.Title);
    }
}
