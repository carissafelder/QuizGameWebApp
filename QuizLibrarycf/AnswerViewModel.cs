using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizLibrarycf
{
    public class AnswerViewModel
    {
        public AnswerViewModel()
        {

        }
    public AnswerViewModel(Answer answer)
    {
        AnswerId = answer.AnswerId;
        QuestionId = answer.QuestionId;
        Content = answer.Content;
        ImageUrl = answer.ImageUrl;
        Reason = answer.Reason;
    }
    public int AnswerId { get; set; }
    public int QuestionId { get; set; }
    public string Content { get; set; }
    public string ImageUrl { get; set; }
    public string Reason { get; set; }

 }
}
