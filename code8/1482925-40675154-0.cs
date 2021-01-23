                try
                {
                    if (!XMLSerial.CanDeserialize(reader))
                    {
                        throw (new WrongFileException("Wrong data sructure for PanelList"));
                     }
                    using (FileStream fsRead = new FileStream(opendlg.FileName, FileMode.Open, FileAccess.Read))
                    {
                        PanelList = XMLSerial.Deserialize(fsRead) as List<Panel>;
                    }
                    PanelBoxListView.ItemsSource = PanelList;
                    PanelBoxListView.Items.Refresh();
                }
                catch(WrongFileException q)
                {
                    MessageBox.Show("WrongFileException: {0}", q.Message);
                    throw;
                }
