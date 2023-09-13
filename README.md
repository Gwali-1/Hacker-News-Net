# Hacker-News-Net
This is a .Net client package to the Hacker News API.
You can interact with the Api through  six(6) public instance methods and a static method
to retrieve informations like best stories , job stories, comments on a post etc
## Methods 
- TopStoriesJson 
- TopStoriesObjects
- JobStoriesJson
- NewStoriesJson
- BestStoriesJson
- GetComments - _All Comments  on a particular Story_

... in Json Format mostly

The Hacker News API is faily minimal and easy to use, this client mostly does the work of exposing easy to call methods and the convenience of returning to you a collection of json instead of a list
of story ids as most endpoints do.
There is also a method `(TopStoriesObjects)` which  returns a collection of stories as a collection of iterative native objects(`story`) for easy access and information retrieval. 


## Installation
You can install the Hacker-News-Net Client using NuGet Package Manager:

```bash
dotnet add package Hacker-News-Net
```
or just add package in the `Visual Studio`

## Basic usage

```csharp
using HackerNewsApiClient;

//get top 10 stories
HackerNews hn  = new HackerNews();
string topStories = await hn.TopStoriesJsom(10);


//get top 10 new stories
string topStories = await hn.NewStoriesJson(10);



//get top 10 Best stories
string topStories = await hn.BestStoriesJson(10);
```

```csharp
//search for an item with id
HackerNews hn  = new HackerNews();
string story = await HackerNews.SearchItem(<item id>);



//get top 10 stories as a collection of obects
List<Story> storiesAsObject = await hn.TopStoriesObjects(10)
foreach(story in storiesAsObject)
{
  //use objects
}
```
```csharp

//get all comments on an item
HackerNews hn  = new HackerNews()
string comments = await hn.GetComments(<item id>)

//get comments on an item with range
HackerNews hn hackerNewsClient = new HackerNews()
string comments = await hn.GetComments(<item id>, offset, limit)


```
