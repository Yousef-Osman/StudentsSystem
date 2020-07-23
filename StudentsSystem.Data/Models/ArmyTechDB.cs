namespace StudentsSystem.Data.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ArmyTechDB : DbContext
    {
        public ArmyTechDB()
            : base("name=ArmyTechDB")
        {
        }

        public virtual DbSet<Field> Fields { get; set; }
        public virtual DbSet<Governorate> Governorates { get; set; }
        public virtual DbSet<Neighborhood> Neighborhoods { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentTeacher> StudentTeachers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Field>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.Field)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Governorate>()
                .HasMany(e => e.Neighborhoods)
                .WithRequired(e => e.Governorate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Governorate>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.Governorate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.StudentTeachers)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.StudentTeachers)
                .WithRequired(e => e.Teacher)
                .WillCascadeOnDelete(false);
        }
    }
}
