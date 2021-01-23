                    public delegate void InvokeDelegate();
                     private void Invoke_Click(object sender, EventArgs e)
                        {
                          mole.BeginInvoke(new InvokeDelegate(InvokeMethod));
                        }
                           public void InvokeMethod()
                         {
                          //  change your mole position here
                           }
