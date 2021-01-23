    private async void btnSelect_Click(object sender, EventArgs e) {
        loadingSpiner.Visible = true;
        btnSelect.Enabled = false;
        int index = listProcess.SelectedIndex;
        MainFormData data = await startMainForm(index);
        Program.mainForm = new MainForm(data);
        this.Hide();
        Program.mainForm.Show();
    }
    private async Task<MainFormData> startMainForm(int index) {
        await Task.Run(() => {
             MainFormData data = new MainFormData();
             data.Initialize(runningProcess[index]);
             return data;
        });
    }
    class MainFormData
    {
        public MainFormData() { ... }
        // You don't say what "runningProcess[index]" is, so placeholder here...
        public void Initialize(object o) { ... }
    }
