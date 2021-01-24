        List<string> questions = new List<string>();
        questions.Add("Yes"); // Added yes option to prompt
        questions.Add("No"); // Added no option to prompt
        string QuestionPrompt = "Are you sure?";
        PromptOptions<string> options = new PromptOptions<string>(QuestionPrompt, "", "", questions, 1); // Overrided the PromptOptions Constructor.
       PromptDialog.Choice<string>(context, NextQuestionAsync, options);
          
