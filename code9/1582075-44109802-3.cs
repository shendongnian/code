     private void OnQuestionAnswered(object sender, EventArgs args)
            {
                var buttonClicked = sender as Button;
                var buttonClickedAnswer = buttonClicked.StyleId;
                
                // Ugly way to get the count
                //var s = new List<object>(ConfirmationQuestionsCarousel.ItemsSource.Cast<object>()).Count;
                // Better way to get the count
                int count = 0;
    
                foreach (var item in ConfirmationQuestionsCarousel.ItemsSource)
                {
                    count++;
                }
    
                // This is to set the Carosel's Position - this is unfinished code, I put it here only as an example
                ConfirmationQuestionsCarousel.Position = 3;
            }
