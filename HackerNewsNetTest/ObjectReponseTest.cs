using Hacker_news_net;
namespace HackerNewsNetTest;


[TestClass]
public class TestTopStoriesObjects
{
    [TestMethod]
    public async Task TestIfParameterLessThanOne()
    {
        HackerNews hn = new HackerNews();
        var result = await hn.TopStoriesObjects(0);
        Assert.IsTrue(result.Count == 0);
    }


    [TestMethod]
    public async Task TestOutOfRangeHandledException()
    {
        HackerNews hn = new HackerNews();
        var result = await hn.TopStoriesObjects(2000000);
        Assert.IsTrue(result.Count == 0);

    }


    [TestMethod]
    public async Task TestObjectsForMoreThanOneResponse()
    {
        HackerNews hn = new HackerNews();
        var result = await hn.TopStoriesObjects(2);
        Assert.IsTrue(result.Count > 1);
        Assert.IsTrue(result[0].Title != null);



    }

    [TestMethod]
    public async Task TestObjectsForOneResponse()
    {
        HackerNews hn = new HackerNews();
        var result = await hn.TopStoriesObjects(1);
        Assert.IsTrue(result.Count == 1);
        Assert.IsTrue(result[0].Title != null);



    }

}
