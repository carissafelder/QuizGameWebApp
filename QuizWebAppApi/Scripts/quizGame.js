$(document).ready(function () {
    var nextQuestionButton = document.getElementById('next-question-button'),
        questionArea = document.getElementById('question-area'),
        currentQuestionId;

    var clickHandler = function clickHandler(event){

        var answerSubmission = { questionId: currentQuestionId, answerId: event.currentTarget.id};
        
        $.getJSON("/api/quizquestion/isanswercorrect/", answerSubmission)
            .done(function (data) {
                if (data.IsCorrect) {
                    alert("Congratulations! That's right");
                }else {
                    alert("Sorry! That wasn't correct!");
                }
            })
            .fail(function (jgxhr, textStatus, error) {
                alert("Whoops! Something went wrong!");
            });

    }
    nextQuestionButton .addEventListener('click', function () {
        $.getJSON('/api/quizquestion', function (data) {
            var questionDiv = document.createElement('div');
            questionArea.innerHTML = "";
            currentQuestionId = data.QuestionId;
            questionDiv.id = currentQuestionId;
            questionDiv.innerText = data.Content;
            questionArea.appendChild(questionDiv);

            data.Answers.forEach(function (val) {
                var answerDiv = document.createElement('div');
                answerDiv.innerText = val.Content;
                answer.Div.id = val.AnswerId;
                answerDiv.addEventListener('click', clickHandler);
                questionArea.appendChild(answerDiv);
            });
        });
    });
});