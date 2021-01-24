    // Get IP from DG adrress
                try
                {
                    IPHostEntry hostEntry = Dns.GetHostEntry("URL");
                    IPAddress[] address = hostEntry.AddressList;
                    textBox.Text = address.GetValue(0).ToString();
                }
                catch
                {
                    // Catches Exception and moves on
                    // MessageBox.Show("No result", "Error");
                }
