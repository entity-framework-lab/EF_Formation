namespace EF_Formation.Data
{
    using EF_Formation.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ModelStudents : DbContext
    {

        public ModelStudents()
            : base("name=ModelStudents")
        {
        }

   
         public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<Student>().HasRequired(s => s.Group3).WithMany().WillCascadeOnDelete(false);
        }
    }
}


