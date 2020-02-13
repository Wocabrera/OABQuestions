namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryQuestions",
                c => new
                    {
                        CategoryQuestionId = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.CategoryQuestionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 1000),
                        AnswerId = c.Int(nullable: false),
                        CategoryQuestionId = c.Int(nullable: false),
                        TestColorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.CategoryQuestions", t => t.CategoryQuestionId, cascadeDelete: true)
                .ForeignKey("dbo.TestColors", t => t.TestColorId, cascadeDelete: true)
                .Index(t => t.CategoryQuestionId)
                .Index(t => t.TestColorId);
            
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        AnswerId = c.Int(nullable: false, identity: true),
                        Content = c.String(maxLength: 1000),
                        IsCertain = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AnswerId);
            
            CreateTable(
                "dbo.TestColors",
                c => new
                    {
                        TestColorId = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.TestColorId);
            
            CreateTable(
                "dbo.AnswerQuestions",
                c => new
                    {
                        Answer_AnswerId = c.Int(nullable: false),
                        Question_QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Answer_AnswerId, t.Question_QuestionId })
                .ForeignKey("dbo.Answers", t => t.Answer_AnswerId, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.Question_QuestionId, cascadeDelete: true)
                .Index(t => t.Answer_AnswerId)
                .Index(t => t.Question_QuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "TestColorId", "dbo.TestColors");
            DropForeignKey("dbo.Questions", "CategoryQuestionId", "dbo.CategoryQuestions");
            DropForeignKey("dbo.AnswerQuestions", "Question_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.AnswerQuestions", "Answer_AnswerId", "dbo.Answers");
            DropIndex("dbo.AnswerQuestions", new[] { "Question_QuestionId" });
            DropIndex("dbo.AnswerQuestions", new[] { "Answer_AnswerId" });
            DropIndex("dbo.Questions", new[] { "TestColorId" });
            DropIndex("dbo.Questions", new[] { "CategoryQuestionId" });
            DropTable("dbo.AnswerQuestions");
            DropTable("dbo.TestColors");
            DropTable("dbo.Answers");
            DropTable("dbo.Questions");
            DropTable("dbo.CategoryQuestions");
        }
    }
}
