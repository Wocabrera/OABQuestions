using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    [Table("CategoryQuestions")]
    public class CategoryQuestion
    {
        [Key]
        public int CategoryQuestionId { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}