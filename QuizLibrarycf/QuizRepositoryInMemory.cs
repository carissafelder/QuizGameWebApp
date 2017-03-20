using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace QuizLibrarycf
{
    public class QuizRepositoryInMemory : IQuizRepository
    {
        //Instantiate and create a contructor.
        private List<Question> _questionList = new List<Question>();
        //This can be used in lots of instances.
        private static Random _randy = new Random();
        private static int nextId = 0;

        //A way to get the whole list 
        public List<Question> GetQuestions()
        {
            return _questionList;
        }
        //This is the max# ques I want back
        public List<Question> GetQuestions(int maxNumberOfQuestions)
        {
            //if the list is empty
            if (_questionList.Count == 0)
            {
                return _questionList;
            }
            //create a new list that will contain the number of questions requested
            //This is the one we'll return, NOT the whole list!
            List<Question> returnList = new List<Question>();

            for (int i = 0; i < maxNumberOfQuestions; i++)
            {
                //idea 1: get the question at the random index in the list
                int myRandomNumber = _randy.Next(0, _questionList.Count);

                //Get the quest from the whole list at the index
                //of the random number we just generated.
                //Add that question to the returnlist
                returnList.Add(_questionList[myRandomNumber]);

            }

            return returnList; //The temporary list we created
        }

        public Question GetQuestionById(int id)
        {
            return _questionList.Find(question => question.QuestionId == id);
        }
        //This is like the edit
        public void UpdateQuestion(Question updateQuestion)
        {
            _questionList.RemoveAll(question => question.QuestionId == updateQuestion.QuestionId);
            _questionList.Add(updateQuestion);
        }
        //get a single question
        public QuestionViewModel GetQuestion()
        {
            return new QuestionViewModel(GetQuestions(1)[0]);
        }
        //add a question
        public void AddQuestion(Question newQuestion)
        {
            newQuestion.QuestionId = nextId++;
            _questionList.Add(newQuestion);
        }

        public void DeleteQuestion(int id)
        {
            _questionList.RemoveAll(question => question.QuestionId == id);
        }

         public void LoadSampleQuestions()
        {
            Question q1 = new Question
            {   
                //I can modify these to replace in my app; this is a base so far.
                Category = "Test Question",
                QuestionType = "Multiple Choice",
                Content = "What is HTML?",
                Answers = new List<Answer>
                {
                    new Answer
                    {
                        AnswerId = 0,
                        Content = "HyperTextModelLanguage",
                        isCorrect = false

                    },
                     new Answer
                    {
                        AnswerId = 1,
                        Content = "HelloThereModelLanguage",
                        isCorrect = true

                    },

                     new Answer
                    {
                        AnswerId = 2,
                        Content = "HelpTakeMovinglightly",
                        isCorrect = false

                    },
                    new Answer
                    {
                        AnswerId = 3,
                        Content = "Green",
                        isCorrect = false

                    }
                }
            };
            AddQuestion(q1);
        }
    }
}
