using TechTalk.SpecFlow;

[Binding]
public sealed class Hooks
{
    [BeforeScenario]
    [Obsolete]
    public void BeforeScenario()
    {
        Console.WriteLine("Starting Scenario: " + ScenarioContext.Current.ScenarioInfo.Title);
    }

    [AfterScenario]
    [Obsolete]
    public void AfterScenario()
    {
        Console.WriteLine("Finished Scenario: " + ScenarioContext.Current.ScenarioInfo.Title);
    }
}
