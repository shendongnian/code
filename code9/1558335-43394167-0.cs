    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            bool completed = await Task.Run(() => DoSomethingLong());
            if (!completed)
            {
                Console.WriteLine("Not completed");
            }
            else
            {
                Console.WriteLine("Completed");
            }
        }
        bool DoSomethingLong()
        {
            //This loop will take 15 seconds
            for (int i = 0; i < 30; i++)
            {
                if (i % 10 == 0)
                    Console.WriteLine("<DoSomethingLong> - I am alive");
                Thread.Sleep(500);
            }
            return true;
        }
    } 
