    class Program
    {
        private static Form form = new Form();
        private static Label label = new Label();
        static void Main(string[] args)
        {
            label.Text = "hi";
            form.Controls.Add(label);
            form.Load += Form_Load; // Add handle to load event of form
            form.ShowDialog();
            Application.DoEvents();
        }
        private async static void Form_Load(object sender, EventArgs e)
        {
            await Task.Run(() =>             // Run async Task for change label.Text
            {
                Thread.Sleep(2000);
                if (label.InvokeRequired)
                {
                    label.Invoke(new Action(() =>
                    {
                        label.Text = "bye";
                        label.Invalidate();
                        label.Update();
                    }));
                }
            });
        }
    }
