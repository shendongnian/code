    public partial class Form1 : Form
    {
        private async void button1_Click(object sender, EventArgs e)
        {
            Progress<int> reporter = new Progress<int>(number =>
            {
                textBox1.Text = number.ToString();
            });
            await Task.Run(() => MyClass1.MyMethod(reporter));
        }
    }
    public class Class1
    {
        public static int MyMethod(IProgress<int> reporter)
        {
            for (int i = 1; i <= 20; ++i)
            {
                reporter.Report(i);
                //Thread.Sleep(100);
            }
            return i;
        }
    }
