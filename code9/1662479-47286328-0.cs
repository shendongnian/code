                StreamReader reader = new StreamReader(response.GetResponseStream());
                string data = reader.ReadToEnd();
                if (data == "Changed")
                {
                    label2.Visible = false;
                    button1.Enabled = false;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    button5.Enabled = true;
                    button6.Enabled = true;
                    button7.Enabled = true;
                    button8.Enabled = true;
                    timer1.Enabled = true;
                }
                else if (data == "Unassigned")
                {
                    string message = "Error Code: B66794O37945O46791K@@Error booking on.@Please make sure you have been assigned to a vehicle.@@If this error persists please contact K.McCrudden.";
                    message = message.Replace("@", "" + System.Environment.NewLine);
                    string title = "Error!";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                }
                else
                {
                    string message = "Error Code: B002875O46883O84655K@@Error booking on.@Please make sure you have booked a shift and have been assigned.@@If this error persists please contact K.McCrudden.";
                    message = message.Replace("@", "" + System.Environment.NewLine);
                    string title = "Error!";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                }
            }
