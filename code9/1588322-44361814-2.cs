     var selected = MyComboBox.SelectedItem as ComboBoxItem;
            if(selected!=null)
            {
                var dataYouNeed = selected.DataContext as TypeOfDataYouDifined; //string or some Class
                if(dataYouNeed!=null)
                {
                    //do your stuff here...
                }
            }
