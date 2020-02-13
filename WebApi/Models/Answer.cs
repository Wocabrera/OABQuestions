using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    [Table("Answers")]
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }

        [MaxLength(1000)]
        public string Content { get; set; }

        public bool IsCertain { get; set; }

        public ICollection<Question> Questions { get; set; }

    }
}