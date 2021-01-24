         public void Del_in()
        {
            if (Listbox2.SelectedIndex > -1)
            {
                Listbox2.Items.RemoveAt(Listbox2.SelectedIndex);
                using (FileStream fs = new FileStream(filepath, FileMode.Create, FileAccess.Write))
                {
                    using (TextWriter tw = new StreamWriter(fs))
                        foreach (string item in Listbox2.Items)
                            tw.WriteLine(item);
                }
            }
        }
