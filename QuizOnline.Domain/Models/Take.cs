using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizOnlineDatabase
{
    public class Take : BaseModel
    {
        [Required]
        public int Point { get; set; }


        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; }
        //[ForeignKey("Student")]
        //public int TestSubjectId { get; set; }
        public TestSubject TestSubject { get; set; }

    }
}
