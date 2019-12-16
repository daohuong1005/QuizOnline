using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuizOnline.Domain
{
    public interface IQuizOnlineDbContextInitializer
    {
        bool EnsureCreated();
        void Migrate();
        Task Seed();
    }
}
