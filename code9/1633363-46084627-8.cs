    private void calculateButton_Click(object sender, EventArgs e)
    {
        try
        {
            // if not existing you have to create some input textboxes
            double startMiles = Convert.ToDouble(startMilesTextBox.Text);
            double endMiles = Convert.ToDouble(endMilesTextBox.Text);
            double days = Convert.ToDouble(daysTextBox.Text);
            // Hint: you are creating a new instance on every button click 
            //       and overwriting your field in your form class. 
            aCarRental = new RentalAgencyClass(startMiles, endMiles, days);
            aCarRental.customerName = nameTextBox.Text;
            aCarRental.phoneNumber = phoneTextBox.Text;
        
            // Store the result in local variables
            // if you want to do something with them later
            double dayCharge = aCarRental.getDayCharge();
            double milesCharge = aCarRental.getMilesCharge();               
            double drivenMiles = aCarRental.milesDriven;
            // displayLabel.Text = "(student information saved)";
        }
        catch (Exception err)
        {
            MessageBox.Show(err.Message, "Error");
        }
        //Displays information about the Rental
        confirmLabel.Text = aCarRental.GetInfo();
    }
