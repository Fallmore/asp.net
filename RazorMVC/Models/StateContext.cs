using Microsoft.EntityFrameworkCore;

namespace RazorMVC.Models
{
	public partial class StateContext : DbContext
	{
		public StateContext()
		{
		}

		public StateContext(DbContextOptions<StateContext> options)
			: base(options)
		{
		}

		public virtual DbSet<State> States { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.UseNpgsql(File.ReadAllText("../connection.txt"));

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasPostgresExtension("uuid-ossp");

			modelBuilder.Entity<State>(entity =>
			{
				entity.HasKey(e => e.IdState).HasName("state_pkey");

				entity.ToTable("state");

				entity.HasIndex(e => new { e.Title, e.Author }, "unique_error").IsUnique();

				entity.Property(e => e.IdState)
					.HasDefaultValueSql("uuid_generate_v4()")
					.HasColumnName("id_state");
				entity.Property(e => e.Author)
					.HasColumnType("character varying")
					.HasColumnName("author");
				entity.Property(e => e.Category)
					.HasColumnType("character varying")
					.HasColumnName("category");
				entity.Property(e => e.Content).HasColumnName("content");
				entity.Property(e => e.Description).HasColumnName("description");
				entity.Property(e => e.PostTime)
					.HasDefaultValueSql("now()")
					.HasColumnType("timestamp without time zone")
					.HasColumnName("post_time");
				entity.Property(e => e.Title)
					.HasColumnType("character varying")
					.HasColumnName("title");
				entity.Property(e => e.Watches)
					.HasDefaultValue(0)
					.HasColumnName("watches");
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}

}