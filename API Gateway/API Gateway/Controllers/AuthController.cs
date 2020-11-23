using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Octokit;
using Octokit.Internal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_Gateway.Controllers
{
    [Route("[controller]/[action]")]
    public class AuthController : Controller
    {

        public IReadOnlyList<Repository> Repositories { get; set; }
        public IReadOnlyList<Repository> StarredRepos { get; set; }
        public IReadOnlyList<User> Followers { get; set; }
        public IReadOnlyList<User> Following { get; set; }

        [HttpGet]
        public IActionResult Login(string returnUrl = "/auth/LoggedIn")
        {
            var result = Challenge(new AuthenticationProperties() { RedirectUri = returnUrl });
            return result;
        }


        [HttpGet]
        public async Task<IActionResult> LoggedIn()
        {
            string accessToken="";
            if (User.Identity.IsAuthenticated)
            {
                accessToken = await HttpContext.GetTokenAsync("access_token");
                var github = new GitHubClient(new ProductHeaderValue("AspNetCoreGitHubAuth"), new InMemoryCredentialStore(new Credentials(accessToken)));
              
            }

            return Ok(accessToken);
        }


    }
}