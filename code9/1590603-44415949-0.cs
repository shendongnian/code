    foreach(var item in question.Answers){
    
        var button = new Button{Text=item.AnswerText};
        button.Clicked += async(s,e)=> await Navigation.PushAsync(item.NextPage);
        stack.Children.Add(button);
    }
