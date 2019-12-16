using Microsoft.EntityFrameworkCore;
using QuizOnlineDatabase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuizOnline.Domain
{
    public class QuizOnlineDbContextInitializer : IQuizOnlineDbContextInitializer
    {
        private readonly QuizOnlineDbContext _context;

        public QuizOnlineDbContextInitializer(QuizOnlineDbContext context)
        {
            _context = context;
        }

        public bool EnsureCreated()
        {
            return _context.Database.EnsureCreated();
        }

        public void Migrate()
        {
            _context.Database.Migrate();
        }

        public Task Seed()
        {
            throw new System.NotImplementedException();
        }
    }
}
