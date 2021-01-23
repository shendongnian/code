    foreach (string item in Time)
                {
                    var n = Convert.ToDateTime(item);
                    if (n.ToString("HH:mm") == DateTime.Now.ToString("HH:mm"))
                    {
                        MessageBox.Show("Test");
                    }
                }
