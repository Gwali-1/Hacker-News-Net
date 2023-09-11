using Newtonsoft.Json;
namespace FrontPage
{
    public class HackerNews
    {
        private readonly HttpClient? client;
        private readonly string? topStoriesUrl;
       


        public HackerNews()
        {
            client = new HttpClient();
            topStoriesUrl = "https://hacker-news.firebaseio.com/v0/topstories.json?print=pretty";
        }

        private async Task<List<Story>> getStoryInfo(List<string> ids)
        {
            List<Story> stories = new List<Story>();

            foreach (var id in ids)
            {
                string url = $"https://hacker-news.firebaseio.com/v0/item/{id.Trim()}.json?print=pretty";
                HttpResponseMessage story = await new HttpClient().GetAsync(url);
                string jsonResponse = await story.Content.ReadAsStringAsync();
               
                Story storyInfo = JsonConvert.DeserializeObject<Story>(jsonResponse);
                if(storyInfo == null)
                {
                    continue;
                }
                stories?.Add(storyInfo);
            }

            return stories;
        }


        public async Task<List<Story>> TopStoriesJson(int number)
        {
            using (client)
            {
                try
                {
                 
                    HttpResponseMessage response = await client.GetAsync(this.topStoriesUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("suncces");
                        Console.WriteLine("converting");
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        string cleanedREsponse = jsonResponse.Trim().Substring(1, jsonResponse.Length - 3);
                        List<string> storyIDs = cleanedREsponse.Split(",").ToList().GetRange(0, number);
                        List<Story> TopStories =  await this.getStoryInfo(storyIDs);
                        return TopStories;



                    }
                    Console.WriteLine($"not success {response.StatusCode}");
                    return new List<Story>{};
                }
                catch (HttpRequestException e)
                {
                    throw e;
                }

            }

        }


     
    }

}
