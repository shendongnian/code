	// ... in your MainForm class ...
	private void button1_Click(object sender, EventArgs e)
	{
		// when you create your instances of ImageViewer, wire up their ImageChecked() event:
		ImageViewer iv = new ImageViewer();
		iv.ImageChecked += Iv_ImageChecked;
	}
	private void Iv_ImageChecked(ImageViewer sender, string message)
	{
		ImageViewer iv = (ImageViewer)sender; // if you need to reference it for other reasons ...
		stripSelectedFile.Text = message;
		txInformation.Text = message;
	}
