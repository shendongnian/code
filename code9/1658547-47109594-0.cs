    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            // async show loading form dialog
            var loadingForm = new LoadingForm();
            var loadingDialogTask = this.InvokeAsync(loadingForm.ShowDialog);
            // async loading data
            var data = await LoadDataAsync();
            listBox1.DataSource = data;
            loadingForm.Close();
            await loadingDialogTask;
        }
        private async Task<ICollection<string>> LoadDataAsync()
        {
            // fake work load
            await Task.Delay(4000).ConfigureAwait(false);
            return Enumerable.Range(1,20000).Select(e => e.ToString()).ToList();
        }
    }
