using Hacker_news_net;
namespace HackerNewsNetTest;




[TestClass]
public class TestGetCommetsMethodWithoutRange
{
    [TestMethod]
    public async Task TestIfWrongStoryId()
    {
        HackerNews hn = new HackerNews();
        var result = await hn.GetComments("kmefme//");
        var expected = "{}";
        Assert.AreEqual(expected, result);

        
    }


    [TestMethod]
    public async Task TestIfCorrectStoryId()
    {
        HackerNews hn = new HackerNews();
        var result = await hn.GetComments("37490241");
        var notExpected = "{}";
        Assert.AreNotEqual(notExpected, result);
        Assert.AreEqual('[', result[0]);


    }

}


[TestClass]
public class TestGetCommetsMethodWithRange
{
    [TestMethod]
    public async Task TestIfLimitLessThanOne()
    {
        HackerNews hn = new HackerNews();
        var result = await hn.GetComments("37490241",2,0);
        var expected = "{}";
        Assert.AreEqual(expected, result);


    }


    [TestMethod]
    public async Task TestIfOffsetLessThanZero()
    {
        HackerNews hn = new HackerNews();
        var result = await hn.GetComments("37490241", -1, 2);
        var expected = "{}";
        Assert.AreEqual(expected, result);


    }

    [TestMethod]
    public async Task TestJSonFormatForOneResponse()
    {
        HackerNews hn = new HackerNews();
        var result = await hn.GetComments("37490241", 0, 1);
        var expected = '{';
        Assert.AreNotEqual("{}", result);
        Assert.AreEqual(expected, result[0]);


    }

    [TestMethod]
    public async Task TestJSonFormatForMoreThanOneResponse()
    {
        HackerNews hn = new HackerNews();
        var result = await hn.GetComments("37490241", 0, 2);
        var expected = '[';
        Assert.AreNotEqual("{}", result);
        Assert.AreEqual(expected, result[0]);


    }


}


