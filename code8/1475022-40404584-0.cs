    class MyForm : Form
    {
        public Label label;
        public MyForm()
        {
            label = new Label();
            label.Text = "Working";
            this.Controls.Add(label);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyForm f = new MyForm();
            (new Task(() =>
            {
                while (true)
                {
                    f.Invoke(new Action(() =>
                    {
                        f.label.Text += ".";
                    }));
                    Console.WriteLine("working...");
                    Thread.Sleep(500);
                }
            })).Start();
            f.ShowDialog();
        }
    }
