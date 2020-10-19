using CollegeCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeData
{
    public class CollegeDbContext : DbContext
    {

        public CollegeDbContext(DbContextOptions<CollegeDbContext> options) : base(options)
        { }

        public DbSet<Student> Students { get; set; }
        public DbSet <Subject> Subjects { get; set; }

        protected override void  OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Students>().HasKey(x => new { x.StudentId, x.SubjectId });
        }
    }
}
