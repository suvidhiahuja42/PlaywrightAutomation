using NUnit.Framework;
using Reqnroll;
using SauceDemoAutomation.Pages;

[Binding]
public class LoginSteps
{
    private readonly LoginPage _loginPage;
    private readonly ScenarioContext _scenarioContext;

    public LoginSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));
        _loginPage = _scenarioContext["loginPage"] as LoginPage
                     ?? throw new KeyNotFoundException("The given key 'loginPage' was not present in the ScenarioContext.");
    }

    [Given("I navigate to the SauceDemo login page")]
    public async Task GivenINavigateToTheSauceDemoLoginPage()
    {
        await _loginPage.NavigateAsync();
    }

    [When(@"I login with username ""(.*)"" and password ""(.*)""")]
    public async Task WhenILoginWithUsernameAndPassword(string username, string password)
    {
        _scenarioContext["username"] = username;
        _scenarioContext["password"] = password;

        // Replacing the incorrect FillAsync calls with the LoginAsync method from LoginPage
        await _loginPage.LoginAsync(username, password);
    }

    [Then(@"I should see the products page")]
    public async Task ThenIShouldSeeTheProductsPage()
    {
        // Replacing the incorrect InnerTextAsync call with GetPageTitleAsync from LoginPage
        var title = await _loginPage.GetPageTitleAsync();
        Assert.AreEqual("Products", title);
    }
}
