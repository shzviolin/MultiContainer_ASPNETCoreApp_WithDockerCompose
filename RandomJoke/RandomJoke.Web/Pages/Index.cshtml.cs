using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace RandomJoke.Web.Pages
{
    public class JokeModel
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }
    }

    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public JokeModel Joke { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var request = new System.Net.Http.HttpRequestMessage();
                request.RequestUri = new Uri("http://localhost:5035/api/Joke");
                var response = await client.SendAsync(request);
                var jokeJson = await response.Content.ReadAsStringAsync();

                Joke = JsonConvert.DeserializeObject<JokeModel>(jokeJson);
            }
        }
    }

}
