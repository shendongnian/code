                if (radioButtonLågPrio.Checked)
                {
                    using (var file = new StreamWriter(Path.Combine(mappNamn, "1 - " + textBoxLappText.Text + ".txt")))
                    {
                       Program.mainform.listBoxLappar.Items.Add(textBoxLappText.Text);
                      Program.mainform.listBoxLappar.Update();
                      Program.mainform.listBoxLappar.Refresh(); // access mainform in Program 
                    }
                }
