namespace LW_2.Model
{
    public class State
    {
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required string Description { get; set; }
        public required string Author { get; set; }
        public string Watches { get; set; } = "0";
        public DateTime Date { get; set; } = DateTime.Now;
        public required string Category { get; set; }
    }
}
