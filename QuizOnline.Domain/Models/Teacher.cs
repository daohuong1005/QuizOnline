using QuizOnline.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizOnlineDatabase
{
    public class Teacher 
    {
        [Key,ForeignKey("Account")]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(156)]
        public string Address { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public bool IsDeleted { get; set; } = false;

        public Status Status { get; set; } = Status.Active;
       
        public virtual Account Account { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
