using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizLibrarycf;

namespace QuizCli
{
    class Program
    {
        static void Main(string[] args)
        {
            //I assembled my testing gear
            QuizRepositoryInMemory quizRepo = new QuizRepositoryInMemory();

           
            quizRepo.AddQuestion(new QuizQuestion
            {
                Id = 0,
                Category = "Test",
                Content = "Select your favorite color",
                Answers = new List<Answer>
                {
                    new QuizAnswer
                    {
                        Id=0,
                        Content="Blue",
                        IsCorrect = false
                    }
                }
            });

            quizRepo.AddQuestion(new QuizQuestion
            {
                Id = 1,
                Category = "Test",
                Content = "Select your favorite number",
                Answers = new List<QuizAnswer>
                {
                    new QuizAnswer
                    {
                        Id=0,
                        Content="Blue",
                        IsCorrect = false
                    }
                }
            });
            //I acted to test the method ; called the method
            var resultList = quizRepo.GetQuestions(10);

            if (resultList.Count <= 10)
            {
                Console.WriteLine("Test 1 Passed");
            } else
            {
                Console.WriteLine("Test 1 Failed");

            }

            var testQuestion = quizRepo.GetQuestionById(1);

            if(testQuestion.Content == "Select your favorite number")
            {
                Console.WriteLine("Test 2 Passed");
            }else
            {
                Console.WriteLine("Test 2 Failed");
            }


            var singleQuestion = quizRepo.GetQuestion();
            if (!string.IsNullOrWhiteSpace(singleQuestion.Content))
            {
                Console.WriteLine("Test 3 Passed");
            }
            else
            {
                Console.WriteLine("Test 3 Failed");
            }

        }

    }
}


