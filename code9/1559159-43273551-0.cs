     public void cbCalibrate_CheckedChanged(object sender, EventArgs e)
            {
                CheckState CalibrationBussy;
                SatusBeforeCalibrating = cbDenoise.CheckState;
                if ( cbDenoise.Checked == true)
                {
                    account = "Active";
                    cbDenoise.Show();   
                }
                else if ( cbDenoise.Checked  == false)
                {
                    account = "Deactive";
                  cbDenoise.Show();   
                }
            }
