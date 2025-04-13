using Microsoft.Playwright;
using Reqnroll;
using SauceDemoAutomation.Pages;

[Binding]
public class PlaywrightHooks
{
    private readonly ScenarioContext _scenarioContext;
    private IBrowser _browser;

    public PlaywrightHooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [BeforeScenario]
    public async Task BeforeScenario()
    {
        var playwright = await Playwright.CreateAsync();
        _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
        var context = await _browser.NewContextAsync();
        var page = await context.NewPageAsync();

        // Add LoginPage to ScenarioContext
        var loginPage = new LoginPage(page);
        _scenarioContext["loginPage"] = loginPage;
    }

    [AfterScenario]
    public async Task AfterScenario()
    {
        if (_browser != null)
        {
            await _browser.CloseAsync();
        }
    }
}
