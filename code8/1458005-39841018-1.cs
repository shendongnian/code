        private void Control_DragEnter(object sender, DragEventArgs e)
        {
            var button = e.Data.GetData(typeof(ToolStripButton)) as ToolStripButton;
            if (button != null)
            {
                e.Effect = DragDropEffects.Copy;
                return;
            }
            var element = e.Data.GetData(typeof(DSDPicBox)) as DSDPicBox;
            if (element == null) return;
            e.Effect = DragDropEffects.Move;
        }
