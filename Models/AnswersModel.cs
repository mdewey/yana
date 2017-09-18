using System;
using StackOverflow.Models;

namespace StackOverflow.Models
{
    public class AnswerModel
    {
        public int Id { get; set; }
        public int VoteCount { get; set; }
        public String Body { get; set; }
        public int UserID { get; set; }
        public DateTime PostDate { get; set; }
        public int QuestionID { get; set; }

        public UserModel UserModel { get; set; }
        public QuestionsModel QuestionModel { get; set; }

        public AnswerModel()
        {
        }
    }
}