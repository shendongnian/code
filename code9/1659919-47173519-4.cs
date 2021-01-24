    class QuestionControl : ContentControl
    {
        private Question question;
        private StackLayout QuestionStackLayout { get; }
    
        public QuestionControl()
        {
            QuestionStackLayout = new StackLayout();
            QuestionTextBlock = new TextBlock()
                                     {
                                         Margin = 10,
                                         FontSize = 20
                                     };
            QuestionStackLayout.Children.Add(QuestionTextBlock);
        }
    
        public Question Question 
        {
            get
            {
                return question;
            }
            set
            {
                question = value;
                DisplayQuestion();
            }
        }
    
        private void DisplayQuestion()
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
        
        private CheckBox CreateCheckBoxForAnswer(Answer answer)
        {
            var checkBox new CheckBox()
            {
                Content = answer.Text,
                Margin = 10
            }
            
            checkBox.Checked += (sender, eventArgs) => 
            {
                answer.IsSelected = (sender as CheckBox).IsChecked;
            };
        
            return checkBox;
        }
    }
