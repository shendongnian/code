       string[] goTos = new string[] { "First", "Second", "Third" };
            foreach (string item in goTos)
            {
               System.Windows.Controls.MenuItem goTo = new   System.Windows.Controls.MenuItem();
                goTo.Header = item;
                goTo.Name = "mnu" + item;
                goTo.Click += new RoutedEventHandler(goTo_Click);
                mnuGoTo.Items.Add(goTo);
            }
        }
        void goTo_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
