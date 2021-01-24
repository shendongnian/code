    foreach(var item in question.Answers)
    {
         var button = new Button();
         button.Text = item.AnswerText;
         button.Clicked += async delegate { await Navigation.PushAsync(item.NextPage); };
    
         stack.Children.Add(button);
    }
