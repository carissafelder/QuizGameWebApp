$(document).ready(function () {
    var nextQuestionButton = document.getElementById('next-question-button'),
        quizResponse = document.getElementById('quiz-response'),
        questionArea = document.getElementById('question-area'),
        currentQuestionId;

    var clickHandler = function clickHandler(event) {

        var answerSubmission = { questionId: currentQuestionId, answerId: event.currentTarget.id };

        $.getJSON("/api/quizquestion/isanswercorrect/", answerSubmission)
            .done(function (data) {
                if (data.IsCorrect) {
                    quizResponse.innerText ="Congratulations! That's right!";
                } else {

                    quizResponse.innerText="Sorry! That wasn't correct!";
                }
            })
            .fail(function (jgxhr, textStatus, error) {
                quizResponse.innerText="Whoops! Something went wrong!";
            });

    }
    nextQuestionButton.addEventListener('click', function () {
        $.getJSON('/api/quizquestion', function (data) {
            var questionDiv = document.createElement('div');
            questionArea.innerHTML = "";
            quizResponse.innerText = "";
            currentQuestionId = data.QuestionId;
            questionDiv.id = currentQuestionId;
            questionDiv.classList.add("question");
            questionDiv.innerText = data.Content;
            questionArea.appendChild(questionDiv);

            data.Answers.forEach(function (val) {
                var answerDiv = document.createElement('div');
                
                answerDiv.innerText = val.Content;
                answerDiv.id = val.AnswerId;
                answerDiv.classList.add("answer");
                answerDiv.addEventListener('click', clickHandler);
                questionArea.appendChild(answerDiv);
            });
        });
    });
})