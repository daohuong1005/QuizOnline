using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizOnlineDatabase
{
    public class Major : BaseModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [ForeignKey("Exam")]
        public int SubjectId { get; set; }
        public virtual Exam Exam { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }


    }
}
