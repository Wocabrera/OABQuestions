using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class OABQuestionsContext : DbContext
    {
        public OABQuestionsContext()
            : base(ConfigurationManager.ConnectionStrings["OABQuestionsContext"].ConnectionString)
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<CategoryQuestion> CategoryQuestions { get; set; }

        public System.Data.Entity.DbSet<WebApi.Models.TestColor> TestColors { get; set; }
    }
}