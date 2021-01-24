    partial class Form1 : Form
    {
        async void button1_Click(object sender, EventArgs e)
        {
            Progress<string> progress = new Progress(s => label1.Text = text);
            await new UploadVideo(progress).Run(video);
        }
    }
