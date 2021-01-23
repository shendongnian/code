    class MyForm : Form
    {
        public Label label;
        public MyForm()
        {
            label = new Label();
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
                //your loop
                while (true)
                {
                    f.Invoke(new Action(() =>
                    {
                        f.label.Text = (new Random()).Next().ToString();
                    }));
                    Console.WriteLine("working...");
                    Thread.Sleep(500);
                }
            })).Start();
            f.ShowDialog(); //blocks as long as the form is open
        }
    }
