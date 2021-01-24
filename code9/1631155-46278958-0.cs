    private void LinkLblEisagogiEggrafon_Click(object sender, EventArgs e)
            {
                if (cmbBoxEponimiaPelatiApodeixeisTimologiouEsodon.Text == "")
                {
                    MessageBox.Show("Πρέπει να επιλέξετε Πελάτη", "Προειδοποίηση");
                }
                else
                {
    
                    EggrafesTimologionEsodon eggrTimolEsodon = new EggrafesTimologionEsodon(cmbBoxEponimiaPelatiApodeixeisTimologiouEsodon.Text);//p
                    
                    eggrTimolEsodon.ShowDialog();
    
                    listToFill = eggrTimolEsodon.lst2send;
    
                    AfterProsthikiProionParastatikou(null,null,listToFill);
                    
                    //AfterProsthikiProionParastatikou(null);
                    //this.Refresh();
                    
                }
    
    
            }
