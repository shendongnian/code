        private void listView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if (e.ItemIndex != (listView.Items.Count - 1))
            {
                // Draw the background and focus rectangle for a selected item.
            }
            else
            {
                // Draw the background for an unselected item.
                using (LinearGradientBrush brush =new LinearGradientBrush(e.Bounds, Color.Red, Color.Red, LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillRectangle(brush, e.Bounds);
                }
            }
            // Draw the item text for views other than the Details view.
            if (listView.View != View.Details)
            {
                e.DrawText();
            }
        }
