using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizOnlineDatabase
{
    public class Part : BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Point { get; set; }
        [Required]
        [ForeignKey("TestSubject")]
        public int TestSubjectId {get;set;}
        public virtual TestSubject TestSubject { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
