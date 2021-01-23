    private async Task AskQuestion(IDialogContext context, IAwaitable<IMessageActivity> result)
    {
        // Get our activity
        var activity = await result;
        // Get our question and answers
        var question = this._questionGroups[_currentStep].Questions[_currentQuestion];
        var questionText = question.Text;
        var answers = question.Answers.Select(m => m.Text).ToList();
        var options = new PromptOptions<string>(questionText, options: answers);
        // Ask our question
        Choice<string>(context, GetAnswer, options);
    }
    private async Task GetAnswer(IDialogContext context, IAwaitable<string> result)
    {
        // Ask our question
        await context.PostAsync("Does this work?");
        // If our category is a camera, forward to our QuestionDialog
        await context.Forward(new StepTwoDialog(), ResumeAfter, new Activity { Text = await result }, CancellationToken.None);
    }
