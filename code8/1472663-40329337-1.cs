            //get the user information that we need
            decimal vehicleTax = 0.00m;
            decimal stampDuty = 0.00m;
            decimal insurancepremium = 0.00m;
            decimal Payable = 0.00m;
            decimal registration = 0.00m;
            decimal regoFee = 0.00m;
            //Calculations for private registration                   
            if (radioPrivate.Checked)
            {
                if (wholesalePrice >= 0)
                    stampDuty = wholesalePrice / 100m;
            }
            {
                if (wholesalePrice >= 0)
                    insurancepremium = wholesalePrice / 50m;
            }
            if (weight <= 0)
                vehicleTax = 0.00m;
            else if (weight <= 975.00)
                vehicleTax = 191.00m;
            else if (weight <= 1154.00)
                vehicleTax = 220.00m;
            else if (weight <= 1504.00)
            {
                vehicleTax = 270.00m;
            }
            else if (weight >= 1505.00)
                vehicleTax = 411.00m;
            Payable = stampDuty + regoFee + vehicleTax + insurancepremium; // calculations for total amount payable   
            registration = stampDuty + regoFee + vehicleTax + insurancepremium; // calculations for total registration
                                                                                // message for when input value does not equal designed values
            {
                if (weight <= 0)
                    MessageBox.Show("Your weight value must be atleast above 0, please click the reset button and try again", "Input Error Message!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (wholesalePrice <= 0)
                    MessageBox.Show("Your Wholesale value must be atleast above 0, please click the reset button and try again", "Input Error Message!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // print the information on the screen
            txtVehicleTax.Text = vehicleTax.ToString();
            txtStampDuty.Text = stampDuty.ToString();
            txtinsurancePremium.Text = insurancepremium.ToString();
            txtpayable.Text = Payable.ToString();
            txtregistration.Text = registration.ToString();
