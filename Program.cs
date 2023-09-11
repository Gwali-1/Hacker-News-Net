namespace FrontPage
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            HackerNews hn = new HackerNews();
            var r = await hn.TopStoriesJson(0);

            Console.WriteLine(r);
            Console.ReadLine();

        }
    }

}
