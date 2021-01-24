        void Handle_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            picker = sender as Picker;
            if(picker.SelectedItem.Equals("Monthly")){
                ListActions.ItemsSource = am.GetMonthlyActionsByUserAndDate(CurrentUser.GetUser, DateTime.Now);
            }
            if(picker.SelectedItem.Equals("Yearly")){
                ListActions.ItemsSource = am.GetYearlyActionsByUserAndDate(CurrentUser.GetUser, DateTime.Now);
            }
			if (picker.SelectedItem.Equals("Daily"))
			{
                ListActions.ItemsSource = am.GetDailyActionsByUserAndDate(CurrentUser.GetUser, DateTime.Now);
			}
            
        
			
        }
