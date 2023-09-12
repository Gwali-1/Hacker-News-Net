namespace FrontPage
{
    public class Story
    {
        public string? By { get; set; }
        public int Score { get; set; }
        public int descendants { get; set; }
        public List<int>? Kids { get; set; }
        public string? Title { get; set; }
        public string? Type { get; set; }
        public string? Url { get; set; }
        public int Time { get; set; }
        public long Id { get; set; }
    }

}
