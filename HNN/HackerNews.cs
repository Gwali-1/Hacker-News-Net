using Newtonsoft.Json;
using System.Text;
namespace FrontPage;

public class HackerNews
{
    private readonly HttpClient client =  new HttpClient();
    private readonly string topStoriesUrl = "https://hacker-news.firebaseio.com/v0/topstories.json?print=pretty";
    private readonly string jobStoriesUrl = "https://hacker-news.firebaseio.com/v0/jobstories.json?print=pretty";



    public HackerNews()
    {
    }

    public static async Task<string> SearchItem(string id)
    {
        string SearchItemUrl = $"https://hacker-news.firebaseio.com/v0/item/{id.Trim()}.json?print=pretty";
        using (HttpClient client = new HttpClient())
        {

            try
            {
                HttpResponseMessage response = await client.GetAsync(SearchItemUrl);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return "{}";
                }

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e);
                return "{}";
            }
        }

    }



    private async Task<List<Story>> getStoryInfoAndReturnObjects(List<string> ids)
    {
        List<Story> stories = new List<Story>();

        foreach (var id in ids)
        {
            string url = $"https://hacker-news.firebaseio.com/v0/item/{ids[0].Trim()}.json?print=pretty";
            HttpResponseMessage story = await client.GetAsync(url);
            string jsonResponse =  await story.Content.ReadAsStringAsync();
          
            Story StoryObject = JsonConvert.DeserializeObject<Story>(jsonResponse);
            if (StoryObject == null)
            {
                continue;
            }
            stories.Add(StoryObject);
        }
        return stories;

      
        
    }


    private async Task<string> getStoryInfoAndReturnJsonFormat(List<string> ids)
    {
        List<Story> stories = new List<Story>();
        var storyJSon = new StringBuilder();
        storyJSon.AppendLine("[");

        if (ids.Count == 1)
        {
            string url = $"https://hacker-news.firebaseio.com/v0/item/{ids[0].Trim()}.json?print=pretty";
            HttpResponseMessage story = await new HttpClient().GetAsync(url);
            return await story.Content.ReadAsStringAsync();

        }

        for (int i = 0; i < ids.Count; i++)
        {
            string url = $"https://hacker-news.firebaseio.com/v0/item/{ids[i].Trim()}.json?print=pretty";
            HttpResponseMessage story = await client.GetAsync(url);
            string jsonResponse = await story.Content.ReadAsStringAsync();
            if ((i + 1) == ids.Count)
            {
                storyJSon.AppendLine(jsonResponse);
                continue;
            }

            storyJSon.AppendLine(jsonResponse + ",");
        }

        return storyJSon.Append("]").ToString();
    }



    private string cleanResponse(string response)
    {
        return response.Trim().Substring(1, response.Length - 3);
     
    }


    //top stories
    public async Task<string> TopStoriesJson(int number)
    {
        if(number < 1)
        {
            return "{}";
        }
        using (client)
        {

            try
            {

                HttpResponseMessage response = await client.GetAsync(this.topStoriesUrl);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    string cleaned = this.cleanResponse(jsonResponse);
                    List<string> storyIDs = cleaned.Split(",").ToList().GetRange(0, number);
                    return await this.getStoryInfoAndReturnJsonFormat(storyIDs);

                }
                return "StatusCode: " + response.StatusCode;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e);
                return "{}";
            }

        }

    }


    //job stroies
    public async Task<string> JobStoriesJson(int number)
    {
        using (client)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(this.jobStoriesUrl);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    string cleaned = this.cleanResponse(jsonResponse);
                    List<string> storyIDs = cleaned.Split(",").ToList().GetRange(0, number);
                    return await this.getStoryInfoAndReturnJsonFormat(storyIDs);
                }

                return "StatusCode: " + response.StatusCode;

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e);
                return "{}";
            }
           
        }

    }


    //top stories objects
    public async Task<List<Story>> TopStoriesObjects(int number)
    {

        if (number < 1)
        {
            return new List<Story>{ };
        }
        using (client)
        {
            try
            {

                HttpResponseMessage response = await client.GetAsync(this.topStoriesUrl);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    string cleanedREsponse = jsonResponse.Trim().Substring(1, jsonResponse.Length - 3);
                    List<string> storyIDs = cleanedREsponse.Split(",").ToList().GetRange(0, number);
                    return await this.getStoryInfoAndReturnObjects(storyIDs);

                }
                return new List<Story> { };
               
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e);
                return new List<Story> { };
            }

        }
        
    }








}
