            private void button1_Click(object sender, EventArgs e)
        {
               var  clipboard = Clipboard.GetText();
                if (clipboard.StartsWith("http://"))
                {
                    System.Diagnostics.Process.Start(clipboard);
                }
        }
