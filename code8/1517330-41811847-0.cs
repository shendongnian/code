    private void populateUsage (string[] stringlist, ComboBox comboboxname)
            {
                string[] lineOfContents = stringlist;
                foreach (var line in lineOfContents)
                {
                    comboboxname.Items.Add(line);
                }
            }
