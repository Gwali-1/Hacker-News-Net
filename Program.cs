namespace FrontPage
{




    public class Program
    {

        

        static async Task Main(string[] args)
        {

            HackerNews hn = new HackerNews();

            var r = await hn.TopStoriesJson(5);
            foreach (var item in r)
            {
                Console.WriteLine(item);
            }


            Console.ReadLine();
           
     
 

        }
    }

}
