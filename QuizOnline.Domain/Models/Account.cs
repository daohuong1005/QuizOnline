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
    public class Account 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string UseName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
        [Required]
        public Rank Rank { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public bool IsDeleted { get; set; } = false;

        public Status Status { get; set; } = Status.Active;

        public virtual Teacher Teacher { get; set; }

        public virtual Student Student { get; set; }
    }
}
