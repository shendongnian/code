            try
            {
                // All your code here
                lst.Items.AddRange(listViewItems.ToArray());
            }
            finally
            {
                lst.ResumeLayout();
            }
