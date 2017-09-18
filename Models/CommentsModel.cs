using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverflow.Models
{
    public class CommentsModel
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int UserID { get; set; }
        public DateTime PostDate { get; set; }
        public int QuestionID { get; set; }
        public int AnswerID { get; set; }

        public UserModel UserModel { get; set; }
        public QuestionsModel QuestionModel { get; set; }
        public AnswerModel AnswerModel { get; set; }

        public CommentsModel()
        {
        }
    }
}