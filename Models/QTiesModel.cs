using System;
namespace StackOverflow.Models
{
    public class QTiesModel
    {
        public int ID { get; set; }
        public int QuestionID { get; set; }
        public int TagID { get; set; }

        public QuestionsModel QuestionsModel { get; set; }
        public TagsModel TagsModel { get; set; }
        
    }
}