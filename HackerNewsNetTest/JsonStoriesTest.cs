
using Hacker_news_net;
namespace HackerNewsNetTest;

[TestClass]
public class TestTopStoriesJson
{
    [TestMethod]
    public async Task TestIfParameterLessThanOne()
    {
       HackerNews hn = new HackerNews();
        var result = await hn.TopStoriesJson(0);
        Assert.AreEqual("{}", result);
             
    }

    [TestMethod]
    public async Task TestJSonFormatForOneResponse()
    {
        HackerNews hn = new HackerNews();
        var result = await hn.TopStoriesJson(1);
        var expected = '{';
        Assert.AreNotEqual("{}", result);
        Assert.AreEqual(expected, result[0]);

    }

    [TestMethod]
    public async Task TestJSonFormatForMoreThanOneResponse()
    {
        HackerNews hn = new HackerNews();
        var result = await hn.TopStoriesJson(2);
        var expected = '[';
        Assert.AreNotEqual("{}", result);
        Assert.AreEqual(expected, result[0]);

    }

    [TestMethod]
    public async Task TestOutOfRangeHandledException()
    {
        HackerNews hn = new HackerNews();
        var result = await hn.TopStoriesJson(2000000);
        var expected = "{}";
        Assert.AreEqual(expected, result);

    }

}

[TestClass]
public class TestJobStoriesJson
{
    [TestMethod]
    public async Task TestIfParameterLessThanOne()
    {
        HackerNews hn = new HackerNews();
        var result = await hn.JobStoriesJson(0);
        Assert.AreEqual("{}", result);

    }

    [TestMethod]
    public async Task TestJSonFormatForOneResponse()
    {
        HackerNews hn = new HackerNews();
        var result = await hn.JobStoriesJson(1);
        var expected = '{';
        Assert.AreNotEqual("{}", result);
        Assert.AreEqual(expected, result[0]);

    }

    [TestMethod]
    public async Task TestJSonFormatForMoreThanOneResponse()
    {
        HackerNews hn = new HackerNews();
        var result = await hn.JobStoriesJson(2);
        var expected = '[';
        Assert.AreNotEqual("{}", result);
        Assert.AreEqual(expected, result[0]);

    }

    [TestMethod]
    public async Task TestOutOfRangeHandledException()
    {
        HackerNews hn = new HackerNews();
        var result = await hn.JobStoriesJson(2000000);
        var expected = "{}";
        Assert.AreEqual(expected, result);

    }

}


[TestClass]
public class TestNewStoriesJson
{
    [TestMethod]
    public async Task TestIfParameterLessThanOne()
    {
        HackerNews hn = new HackerNews();
        var result = await hn.NewStoriesJson(0);
        Assert.AreEqual("{}", result);

    }

    [TestMethod]
    public async Task TestJSonFormatForOneResponse()
    {
        HackerNews hn = new HackerNews();
        var result = await hn.NewStoriesJson(1);
        var expected = '{';
        Assert.AreNotEqual("{}", result);
        Assert.AreEqual(expected, result[0]);

    }

    [TestMethod]
    public async Task TestJSonFormatForMoreThanOneResponse()
    {
        HackerNews hn = new HackerNews();
        var result = await hn.NewStoriesJson(2);
        var expected = '[';
        Assert.AreNotEqual("{}", result);
        Assert.AreEqual(expected, result[0]);

    }

    [TestMethod]
    public async Task TestOutOfRangeHandledException()
    {
        HackerNews hn = new HackerNews();
        var result = await hn.NewStoriesJson(2000000);
        var expected = "{}";
        Assert.AreEqual(expected, result);

    }

}



[TestClass]
public class TestBestStoriesJson
{
    [TestMethod]
    public async Task TestIfParameterLessThanOne()
    {
        HackerNews hn = new HackerNews();
        var result = await hn.BestStoriesJson(0);
        Assert.AreEqual("{}", result);

    }

    [TestMethod]
    public async Task TestJSonFormatForOneResponse()
    {
        HackerNews hn = new HackerNews();
        var result = await hn.BestStoriesJson(1);
        var expected = '{';
        Assert.AreNotEqual("{}", result);
        Assert.AreEqual(expected, result[0]);

    }

    [TestMethod]
    public async Task TestJSonFormatForMoreThanOneResponse()
    {
        HackerNews hn = new HackerNews();
        var result = await hn.BestStoriesJson(2);
        var expected = '[';
        Assert.AreNotEqual("{}", result);
        Assert.AreEqual(expected, result[0]);

    }

    [TestMethod]
    public async Task TestOutOfRangeHandledException()
    {
        HackerNews hn = new HackerNews();
        var result = await hn.BestStoriesJson(2000000);
        var expected = "{}";
        Assert.AreEqual(expected, result);

    }

}
