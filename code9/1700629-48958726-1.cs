    private void Form1_DragDrop(object sender, DragEventArgs e) {
        string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
    	if (files == null) {
	        string url = (string)e.Data.GetData(DataFormats.Text);
            MessageBox.Show(url);
       }
    }
	private void Form1_DragEnter(object sender, DragEventArgs e) {
		if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
			e.Effect = DragDropEffects.Copy;
		}
	}
