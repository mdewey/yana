using System;
namespace StackOverflow.Models
{
    public class QuestionsModel
    {
		public int Id { get; set; }
		public int VoteCount { get; set; }
		public string Title { get; set; } //capital or lower?
        public string Body { get; set; }  //capital or lower? 
		public string UserID { get; set; }  //or int?
		public DateTime PostDate { get; set; } = DateTime.Now; 

        public UserModel UserModel { get; set; }

        public QuestionsModel()
        {
        }
    }
}