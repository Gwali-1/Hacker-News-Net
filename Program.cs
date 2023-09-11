
namespace FrontPage
{
    public class Program
    {
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
                        string cleanedREsponse  = jsonResponse.Trim().Substring(1, jsonResponse.Length - 3);

                        Console.WriteLine(cleanedREsponse);
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
