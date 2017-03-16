$(document).ready(function () {
    var addAnswerButton = document.getElementById("add-answer-button"),

        answerDiv = document.getElementById("answer-div"),
        nextId=0;

    //var panelTemplate = 
    var panelTemplate = '<div class="form-group">' +
                    '<label for="Answers[{{index}}].Id"> Id </label>' +
                    '<input type="text" class="form-control" name="Answers[{{index}}].Id" id="Answers[{{index}}].Id" value="{{index}}" />' +
                '</div>' +

                '<div class="form-group">' +
                    '<label for="Answers[{{index}}].Content">Content </label>' +
                    '<input type="text" class="form-control" name="Answers[{{index}}].Content" id="Answers[{{index}}].Content" />' +
                '</div>' +

                '<div class="form-group">' +
                    '<label for="Answers[{{index}}].IsCorrect">Is Correct </label>' +
                    '<input type="checkbox" name="Answers[{{index}}].IsCorrect" id="Answers[{{index}}].IsCorrect" value="true" />' +
                    '<input type="hidden" name="Answers[{{index}}].IsCorrect" id="Answers[{{index}}].IsCorrect" value="false" />' +
                '</div>';
    
        addAnswerButton.addEventListener("click", function () {
        
        var newAnswerHtml = panelTemplate.replace(/{{index}}/g, nextId++);
        var newAnswerDiv = document.createElement("div");
        newAnswerDiv.classList.add("panel");
        newAnswerDiv.innerHTML = newAnswerHtml;

    answerDiv.appendChild(newAnswerDiv);
});
});