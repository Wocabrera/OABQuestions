using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{

    [Table("TestColors")]
    public class TestColor
    {
        [Key]
        public int TestColorId { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}