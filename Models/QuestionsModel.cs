using System;
namespace StackOverflow.Models
{
    public class QuestionsModel
    {
		public int Id { get; set; }
		public int VoteCount { get; set; }
		public string Title { get; set; } //capital or lower?
        public string Body { get; set; }  //capital or lower? 
		public int UserID { get; set; }  //or int?
		public DateTime PostDate { get; set; } = DateTime.Now; 

        public ApplicationUser ApplicationUser { get; set; }

        public QuestionsModel()
        {
        }
    }
}