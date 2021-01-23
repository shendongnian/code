    int counter = 0;
        private void btnAddNewQuestion_Click(object sender, RoutedEventArgs e)
        {
            Button btnQuestion = new Button();
            btnQuestion.Name = "btn" + counter.ToString();
            spMain.Children.Add(btnQuestion);
            btnQuestion.Content = "Enter/Edit your question here";
            btnQuestion.Background = Brushes.Gray;
            btnQuestion.Click += new RoutedEventHandler(btnEnterQuestion_Click);
            counter++;
        }
        private void btnEnterQuestion_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            button.Background = Brushes.White;
            button1.Background = Brushes.Gray; // change of first buttons color
        }
