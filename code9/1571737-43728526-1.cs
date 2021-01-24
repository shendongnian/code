    partial class Form1 : Form
    {
        async void button1_Click(object sender, EventArgs e)
        {
            UploadVideo uv = new UploadVideo();
            uv.StatusTextChanged += (sender, text) =>
            {
                Invoke((MethodInvoker)(() => label1.Text = text));
            }
            await uv.Run(video);
        }
    }
