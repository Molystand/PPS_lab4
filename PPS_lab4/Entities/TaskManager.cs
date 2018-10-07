namespace PPS_lab4.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TaskManager : DbContext
    {
        public TaskManager()
            : base("name=TaskManager")
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Priority> Priority { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Task> Task { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasMany(e => e.Task)
                .WithRequired(e => e.Account)
                .HasForeignKey(e => e.UserId);
        }
    }
}
