using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    [Table("Questions")]
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        [MaxLength(1000)]
        public string Title { get; set; }

        public int AnswerId { get; set; }
        public ICollection<Answer> Answer { get; set; }

        public int CategoryQuestionId { get; set; }
        public CategoryQuestion CategoryQuestion { get; set; }

        public int TestColorId { get; set; }
        public TestColor TestColor { get; set; }
    }
}