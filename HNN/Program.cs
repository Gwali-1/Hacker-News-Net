namespace FrontPage
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            HackerNews hn = new HackerNews();
            var r = await hn.GetComments("8863", 0,2);

            Console.WriteLine(r);


            //var t = await HackerNews.SearchItem("8917");        
            Console.ReadLine();
        }
    }

}
