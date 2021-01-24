    foreach (Sale s in sales)
    {
         //codes above as in your question
         Button btn = new Button { Content = "Удалить", Width = 55, Height = 20, FontSize = 13 }
         btn.Tag = s;
         btn.Click += Btn_Click;
         //codes below as in your question
    }
