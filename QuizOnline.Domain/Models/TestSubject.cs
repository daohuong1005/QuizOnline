using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizOnlineDatabase
{
    public class TestSubject : BaseModel
    {
        [Required]
        public int Time { get; set; }

        public string Note { get; set; }

        [Required]
        public DateTime TimeStarted { get; set; }
        [Required]
        public DateTime TimeEnd { get; set; }


        [Required]
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
        
    }
}
