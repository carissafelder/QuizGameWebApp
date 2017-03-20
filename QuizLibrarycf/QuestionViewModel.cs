using System.Collections.Generic;

namespace QuizLibrarycf
{
    public class QuestionViewModel
    {
        public QuestionViewModel()
        {
            Answers = new List<AnswerViewModel>();
        }
        public QuestionViewModel(Question question)
        {
            Answers = new List<AnswerViewModel>();

            QuestionId = question.QuestionId;
            Category = question.Category;
            Content = question.Content;
            ImageUrl = question.ImageURl;
            MoreInfoUrl = question.MoreInfoUrl;
            QuestionType = question.QuestionType;
            ReasonForAnswer = question.ReasonForAnswer;

            foreach (var answer in question.Answers)
            {
                Answers.Add(new AnswerViewModel(answer));
            }
        }
        public int QuestionId { get; set; }

        public string Category { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public string MoreInfoUrl { get; set; }

        public string QuestionType { get; set; }

        public string ReasonForAnswer { get; set; }

        public List<AnswerViewModel> Answers { get; set; }

    }
}
