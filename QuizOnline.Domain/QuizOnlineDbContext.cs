using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QuizOnlineDatabase;
using System.IO;

namespace QuizOnlineDatabase
{
    public class QuizOnlineDbContext : DbContext
    {
        public QuizOnlineDbContext(DbContextOptions<QuizOnlineDbContext> options)
             : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Take> Takes { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TestSubject> TestSubjects { get; set; }

    }
}