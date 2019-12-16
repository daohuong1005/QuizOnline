using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizOnlineDatabase
{
    public class Question : BaseModel
    {
        [Required]
        public string QuestionsContent { get; set; }

        public string ExplainTheQuestion { get; set; }

        [Required]
        [ForeignKey("Part")]
        public int PartId { get; set; }
        public virtual Part Part { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}
