    private void Service_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                string answer = rb.Content.ToString();
                switch (answer)
                {
                    case "Yes":
                        value = 1;
                        break;
                    case "No":
                        value = 0;
                        break;
                }
            }
            int RID = int.Parse(rb.DataContext.ToString());
            
            Questionnaire temp = selectedItems.FirstOrDefault(x => x.id == RID);
            if(temp == null)
            {
               Questionnaire you = new Questionnaire();
               you.id = RID;
               you.answer = value;
               selectedItems.Add(you);
            }
            else
            {
               temp.answer = value;
            }
        }
