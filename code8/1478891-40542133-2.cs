    private void Form1_KeyUp(object sender, KeyEventArgs e)
                {                
                    if (e.KeyCode.ToString() == "S" || e.KeyCode.ToString() == "W")//Check conditions
                    {
                        try
                        {
                            serialPort1.Write("S");    // Passing the command "Stop" through letter "S" in arduino code//
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Please establish the connection with rover.");
                        }
                    }
                }
