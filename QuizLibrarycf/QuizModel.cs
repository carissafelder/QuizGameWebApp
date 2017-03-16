namespace QuizLibrarycf
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuizModel : DbContext
    {
        public QuizModel()
            : base("name=QuizModelDbContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        //removed virtual next to the public to eliminate lazy loading.
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                .HasMany(e => e.Answers)
                .WithRequired(e => e.Question)
                .WillCascadeOnDelete(true);
                //.WillCascadeOnDelete(false);
        }
    }
}
