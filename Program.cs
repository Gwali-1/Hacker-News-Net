using Newtonsoft.Json;
namespace FrontPage
{

    //public class HackerNews
    //{
    //    private readonly HttpClient? client;
    //    private readonly string? topStoriesUrl;
    //}


    public class Story
    {
        public string By { get; set; }
        public int Score { get; set; }
        public int   descendants { get; set; }
        public List<int> kids { get; set; }
        public string title { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public int time { get; set; }
        public int id { get; set; }
    }


    public class Program
    {

        static async void getStoryInfo(List<string> ids)
        {
            List<Story> stories;
            foreach (var id in ids)
            {
                string url = $"https://hacker-news.firebaseio.com/v0/item/{id.Trim()}.json?print=pretty";
                HttpResponseMessage story = await new HttpClient().GetAsync(url);
                string jsonResponse = await story.Content.ReadAsStringAsync();
                Story? storyInfo = JsonConvert.DeserializeObject<Story>(jsonResponse);
                Console.WriteLine(storyInfo.title);
                Console.WriteLine(storyInfo.id);
                Console.WriteLine(storyInfo.title);
                Console.WriteLine(storyInfo.kids);
                Console.WriteLine(storyInfo.title);



            }
        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("begin");

            HttpClient client;

            using (client = new HttpClient())
            {
                try
                {
                    string topStoriesUrl = "https://hacker-news.firebaseio.com/v0/topstories.json?print=pretty";
                    HttpResponseMessage response = await client.GetAsync(topStoriesUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("suncces");
                        Console.WriteLine("converting");
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        string cleanedREsponse = jsonResponse.Trim().Substring(1, jsonResponse.Length - 3);
                        List<string> storyIDs = cleanedREsponse.Split(",").ToList().GetRange(0,10);
                        getStoryInfo(storyIDs);
                       
                 
                
                        Console.ReadLine();
                        return;
                    }
                    Console.WriteLine($"not success {response.StatusCode}");
                }
                catch ( HttpRequestException)
                {
                    Console.WriteLine("ERROR: THERE WAS A PROBLEM WITH REQUEST");
                }

            }

            Console.WriteLine("end");
            Console.ReadLine();
 

        }
    }

}
