    string[] QuestionChoice = line[3].Split(new string[] { "#" }, StringSplitOptions.RemoveEmptyEntries);
    
    List<RadioButton> radioButtonList = new List<RadioButton>();
    
    radioButtonList.Add(radioButton1);
    radioButtonList.Add(radioButton2);
    radioButtonList.Add(radioButton3);
    radioButtonList.Add(radioButton4);
    
    for ( int i = 0; i < radioButtonList.Count; i++ )
    {
        radioButtonList[i].Content = QuestionChoice[i];//(WPF)i edit the .Text into .Content 
    }
