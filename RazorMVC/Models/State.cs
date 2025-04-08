using System.ComponentModel.DataAnnotations;

namespace RazorMVC.Models
{
    public class State
    {
        [Display(Name = "IdState")]
        public Guid IdState { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; } = null!;

        [Display(Name = "Description")]
        public string Description { get; set; } = null!;

        [Display(Name = "Content")]
        public string Content { get; set; } = null!;

        [Display(Name = "Author")]
        public string Author { get; set; } = null!;

        [Display(Name = "Watches")]
        public int Watches { get; set; }

        [Display(Name = "PostTime")]
        public DateTime PostTime { get; set; }

        [Display(Name = "Category")]
        public string Category { get; set; } = null!;

		public string RoundWatches()
		{
			string roundedWatches = Watches.ToString();
			if (Watches > 999)
				roundedWatches = (Watches % 999).ToString() + " тыс.";
			return roundedWatches;
		}
	}
}
