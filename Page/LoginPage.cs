using Microsoft.Playwright;
using System.Threading.Tasks;

namespace SauceDemoAutomation.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;

        // Selectors
        private readonly string _usernameInput = "#user-name";
        private readonly string _passwordInput = "#password";
        private readonly string _loginButton = "#login-button";
        private readonly string _title = ".title";

        public LoginPage(IPage page)
        {
            _page = page;
        }

        public async Task NavigateAsync()
        {
            await _page.GotoAsync("https://www.saucedemo.com/");
        }

        public async Task LoginAsync(string username, string password)
        {
            await _page.FillAsync(_usernameInput, username);
            await _page.FillAsync(_passwordInput, password);
            await _page.ClickAsync(_loginButton);
        }

        public async Task<string> GetPageTitleAsync()
        {
            return await _page.InnerTextAsync(_title);
        }
    }
}
