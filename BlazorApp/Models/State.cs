using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Models
{
    [PrimaryKey(nameof(IdState))]
    public class State
    {
        [Display(Name = "IdState")]
		[Column("id_state")]
        public Guid IdState { get; set; }

        [Display(Name = "Title")]
		[Column("title")]
		public string Title { get; set; } = null!;

        [Display(Name = "Description")]
		[Column("description")]
		public string Description { get; set; } = null!;

        [Display(Name = "Content")]
		[Column("content")]
		public string Content { get; set; } = null!;

        [Display(Name = "Author")]
		[Column("author")]
		public string Author { get; set; } = null!;

        [Display(Name = "Watches")]
		[Column("watches")]
		public int Watches { get; set; } = 0;

        [Display(Name = "PostTime")]
		[Column("post_time")]
		public DateTime PostTime { get; set; } = DateTime.Now;

		[Display(Name = "Category")]
		[Column("category")]
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
