using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizOnlineDatabase
{
    public class Subject : BaseModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [ForeignKey("Major")]
        public int MajorId { get; set; }
        public virtual Major Major { get; set; }

        [Required]
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        public virtual ICollection<TestSubject> TestSubjects { get; set; }
    }
}
