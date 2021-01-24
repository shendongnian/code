    public partial class Form2 : Form, IWorker
    {
        public Form2()
        {
            InitializeComponent();
        }
        public void RunWorker()
        {
            if (backgroundWorker1.IsBusy) return;
            backgroundWorker1.RunWorkerAsync();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            UtilityX.RunWorker<Form2>();
        }
    }
    public static class UtilityX
    {
        public static void RunWorker<T>() where T : IWorker
        {
            var target = (T)Application.OpenForms.OfType<T>().FirstOrDefault();
            target?.RunWorker();
        }
    }
    public interface IWorker
    {
        void RunWorker();
    }
