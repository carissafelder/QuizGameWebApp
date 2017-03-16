using System.Collections.Generic;

namespace QuizLibrarycf
{
    public interface IQuizRepository
    {
        void AddQuestion(Question newQuestion);
        void DeleteQuestion(int id);
        Question GetQuestion();
        Question GetQuestionById(int id);
        List<Question> GetQuestions();
        List<Question> GetQuestions(int maxNumberOfQuestions);
        void UpdateQuestion(Question updateQuestion);
    }
}