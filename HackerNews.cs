using Newtonsoft.Json;
using System.Text;

namespace FrontPage;

public class HackerNews
{
    private readonly HttpClient? client;
    private readonly string? topStoriesUrl;
   


    public HackerNews()
    {
        
        client = new HttpClient();
        topStoriesUrl = "https://hacker-news.firebaseio.com/v0/topstories.json?print=pretty";
    }

    //static async Task<string> SearchItem(long id)
    //{
    //    //search and return json of item
    //}


  
    private async Task<string> getStoryInfoAndReturnJsonFormat(List<string> ids)
    {
        List<Story> stories = new List<Story>();
        var storyJSon = new StringBuilder();
        storyJSon.AppendLine("[");

        if(ids.Count == 1)
        {
            string url = $"https://hacker-news.firebaseio.com/v0/item/{ids[0].Trim()}.json?print=pretty";
            HttpResponseMessage story = await new HttpClient().GetAsync(url);
            return await story.Content.ReadAsStringAsync();

        }

        for (int i = 0; i < ids.Count; i++)
        {
            string url = $"https://hacker-news.firebaseio.com/v0/item/{ids[i].Trim()}.json?print=pretty";
            HttpResponseMessage story = await new HttpClient().GetAsync(url);
            string jsonResponse = await story.Content.ReadAsStringAsync();
            if ((i + 1) == ids.Count)
            {
                storyJSon.AppendLine(jsonResponse);
                continue;
            }

            storyJSon.AppendLine(jsonResponse+",");
        }

        return storyJSon.Append("]").ToString();
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
                    string cleanedREsponse = jsonResponse.Trim().Substring(1, jsonResponse.Length - 3);
                    List<string> storyIDs = cleanedREsponse.Split(",").ToList().GetRange(0, number);
                    return await this.getStoryInfoAndReturnJsonFormat(storyIDs);

                }
                return "StatusCode: " + response.StatusCode;

            }
            catch (HttpRequestException e)
            {
                throw e;
            }

        }



    }

    //get aks





 
}
