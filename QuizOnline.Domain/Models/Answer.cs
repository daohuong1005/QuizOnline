
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizOnlineDatabase
{
    public class Answer : BaseModel
    {

        [Required]
        [MaxLength(1)]
        public string Symbol { get; set; }
        [Required]
        public string AnswerContent { get; set; }
        [Required]
        public bool CorrectAnswer { get; set; }
        public bool SelectAnswers { get; set; }
        [Required]
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

    }
}
