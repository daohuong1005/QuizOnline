using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizOnlineDatabase
{
    public class Exam : BaseModel
    {
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime ExamDate { get; set; }


        public virtual ICollection<Major> Majors { get; set; }
    }
}
