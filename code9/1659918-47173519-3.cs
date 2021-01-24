    void DisplayQuestion(Question question)
    {
        QuestionTextBlock.Text = question.QuestionText;
        foreach(var answer in question.Answers)
        {
            AddAnswerButton(answer);
        }
    }
    
    private void AddAnswer(Answer answer)
    {
        QuestionStack.Children.Add(CreateButtonForAnswer(answer));
    }
    
    private Button CreateButtonForAnswer(Answer answer)
    {
        var button new Button()
        {
            Content = answer.Text,
            Margin = 10
        }
        
        button.Click += (sender, eventArgs) => 
        {
            // handle button click
        };
    
        return button;
    }
