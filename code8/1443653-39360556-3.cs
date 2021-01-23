    private void Calculatebutton_Click(object sender, EventArgs e)
    {
        string Runner1Name;
        string Runner2Name;
        string Runner3Name;
    
        double Runner1Time;
        double Runner2Time;
        double Runner3Time;
    
        //double FirstPlace;
        //double SecondPlace;
        //double ThirdPlace;
    
      //get runner names
        Runner1Name = Runner1NametextBox.Text;
        Runner2Name = Runner2NametextBox.Text;
        Runner3Name = Runner3NametextBox.Text;
    
    
    
        //check if Runner1Name is empty 
        if (string.IsNullOrEmpty(Runner1Name))
        {
             MessageBox.Show("The Runner 1 Name cannot be empty ", "Invalid Runner Name",
             MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    
        //check if Runner1Name is empty 
        else if (string.IsNullOrEmpty(Runner2Name)) 
        {
            MessageBox.Show("The Runner 2 Name cannot be empty ", "Invalid Runner Name",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    
        else if (string.IsNullOrEmpty(Runner3Name))
        {
           MessageBox.Show("The Runner 3 Name cannot be empty ", "Invalid Runner Name",
           MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    
        else if (!double.TryParse(Runner1TimetextBox.Text, out Runner1Time)) 
    
        {
            MessageBox.Show("Please Input a Positive number for Runner 1", "Invalid Input",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    
        else if  (!double.TryParse(Runner2TimetextBox.Text, out Runner2Time))
        {
            MessageBox.Show("Please Input a Positive number for Runner 2", "Invalid Input",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    
        else if  (!double.TryParse(Runner3TimetextBox.Text, out Runner3Time))
        {
            MessageBox.Show("Please Input a Positive number for Runner 3", "Invalid Input",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    
        Dictionary<string, double> results = new Dictionary<string, double>();
    
        results.Add(Runner1Name, Runner1Time);
        results.Add(Runner2Name , Runner2Time);
        results.Add(Runner3Name , Runner2Time);
    
        var bestTime = results.Min(item => item.Value);
        var worstTime = results.Max(item => item.Value);
        foreach (var item in results)
        {
            if (item.Value == bestTime)
            {
                FirstPlacetextBox.Text = item.Key;
                continue;
            }
            if (item.Value == worstTime)
            {
                ThirdPlacetextBox.Text = item.Key;
                continue;
            }
            SecondPlacetextBox.Text = item.Key;
        }
        
    }
