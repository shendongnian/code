     private void btn_Result_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            MatchesTBL selected = Listbox_Matches.SelectedItem as MatchesTBL;
            if (listBox_ManagersDislay.SelectedItem != null)
            {
                var removeMatch = db.MatchesTBLs.SingleOrDefault(x => x.TeamName == selected.TeamName && x.OpponentName == selected.OpponentName); //returns a single item.
                if (removeMatch != null)
                {
                    switch (comboBox_Result.SelectedIndex)
                    {
                        case 0:
                            MessageBox.Show("You have not selected a result...");
                            break;
                        case 1:
                            // add 3 points
                            var AddWin = (from Team in db.TeamTBLs
                                         where selected.TeamName == Team.TeamName
                                         select Team ).FirstOrDefault();										 
								AddWin.Points=AddWin.Points+3;
								db.Entry(AddWin).State = System.Data.Entity.EntityState.Modified;     
                            break;
                        case 2:
                            // add 1 point
                            var AddDraw = from Team in db.TeamTBLs
                                          where selected.TeamName == Team.TeamName
                                          select Team ).FirstOrDefault();
							AddDraw.Points=AddWin.Points+1;
							 db.Entry(AddDraw).State = System.Data.Entity.EntityState.Modified;   
                            break;
                    }
                    db.MatchesTBLs.Remove(removeMatch);
                    db.SaveChanges();
                }
                // Repeat the on window loaded method to refresh the grids
                Window_Loaded(sender, e);
            }
            else
            {
                MessageBox.Show("Please select a match from the table");
            }
        }
        catch
        {
            MessageBox.Show("An error has occured....");
        }
	}
