     private void editBox(object sender, EventArgs e)
        {
            //if you're using VS2017 with c# 7.0
            if (sender is Button editBoxButton)
            {
                if (editBoxButton.CommandParameter is int temp_boxID)
                    Navigation.PushModalAsync(new EditBoxPage(temp_boxID));
            }
            //if not then we'll go the traditional way
            var editBoxButton = sender as Button;
            if(editBoxButton!=null)
            {
                var boxID = editBoxButton.CommandParameter;
                int temp_boxID;
                int.TryParse(boxID.ToString(), out temp_boxID);
                Navigation.PushModalAsync(new EditBoxPage(temp_boxID));
            }
        }
