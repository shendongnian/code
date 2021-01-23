        private async void panel_DragDrop(object sender, DragEventArgs e)
        {
            var files = await FileDrop.GetFileDrop(e.Data as System.Windows.Forms.DataObject);
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }
