      DataSet dataSet = new DataSet();
                OpenFileDialog sfd = new OpenFileDialog();
                sfd.Filter = "XML|*.xml";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string file = sfd.FileName;
                    try
                    {
                        
                        dt.ReadXml(file);
                       
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
