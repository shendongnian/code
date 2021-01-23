        private void btnVorData_Click(object sender, EventArgs e)
        {
            Count++;
        }
        private void btnZurueckData_Click(object sender, EventArgs e)
        {
            Count--;
        }
        // this method evaluates at which side you are
        private void manageButtons(int value)
        {
            if (value > zeichnungen.Count)
            {
                btnVorData.Enabled = false;
                btnSpeichern.Enabled = true;
            }
            else
            {
                btnZurueckData.Enabled = false;
            }
        }
        // this just enables the forward and backward button and disables the save button
        private void switchButtons()
        {
            btnVorData.Enabled = true; 
            btnZurueckData.Enabled = true;
            btnSpeichern.Enabled = false;
        }
        
    }
