        private void panel_DragDrop(object sender, DragEventArgs e)
        {
            // Test to see where we are dropping. Sender will be control on which you dropped
            var panelDropPoint = sender.PointToClient(new Point(e.X, e.Y));
            var panelItem = sender.GetChildAtPoint(panelDropPoint);
            _insertionPoint = panelItem == null ? destination.Controls.Count : destination.Controls.GetChildIndex(panelItem, false);
            var whodat = e.Data.GetData(typeof(ToolStripButton)) as ToolStripButton;
            if (whodat != null)
            {
                //Dropping from a primitive button
                _dropped = true;
                button.PerformClick();
                return;
            }
          }
