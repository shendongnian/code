    while (ShowNo < Names.Count)
            {
                CustomMessageBox Msg = new CustomMessageBox();
                GlobalForm.Invoke((MethodInvoker)delegate()
                {
                    try
                    {
                        Msg.lblName.Text = Names[ShowNo];
                        Msg.Show();
                        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                        timer.Interval = 2000;
                        timer.Tick += (s, e) => Msg.Close();
                        timer.Start();
                    }
                    catch
                    {
                        t.Abort();
                    }
                    ShowNo++;
                });
            }
