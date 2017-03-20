using QuizLibrarycf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuizWebAppApi.Controllers
{
    public class QuizQuestionController : ApiController
    {
        private static IQuizRepository _quizRepo;

        public QuizQuestionController()
        {
            if (_quizRepo == null)
            {
                _quizRepo = new QuizRepositoryEF();
            }
        }

        public QuizQuestionController(IQuizRepository newRepo)
        {
            _quizRepo = newRepo;

        }

        //Get: api/QuizQuestion
        public QuestionViewModel Get()
        {
            return _quizRepo.GetQuestion();
        }

        [Route("api/quizquestion/isanswercorrect")]
        [HttpGet]
        public AnswerResults IsAnswerCorrect(int questionId, int answerId)
        {
            var question = _quizRepo.GetQuestionById(questionId);
            AnswerResults results = new AnswerResults();
            var selectedAnswer = question.Answers.First(a => a.AnswerId == answerId);

            if (selectedAnswer != null)
            {
                results.IsCorrect = selectedAnswer.isCorrect;
            }

            return results;
        }

            //Get: api/QuizQuestion/5
            public string Get(int id)
        {
            return "value";
        }

        //POST: api/QuizQuestion
        public void Post([FromBody]string value)
        {
        }

        // PUt: api/QuizQuestion/5
        public void PUt(int id, [FromBody]string value)
        {

        }
        //DELETE: api/QuizQuestion/5
        public void Delete(int id)
        {
        }
    }
}
