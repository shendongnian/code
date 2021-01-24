    public partial class Form1 : Form
    {
        // Other form code omitted...
        private async void BtnScan_Click(object sender, EventArgs e)
        {
            listBox1.DataSource = await Task.Run(GetDatasource);
        }
        private async Task<List<string>> GetDatasource()
        {
            var btCom = new BtCom();
            List<string> results = await btCom.Scan();
            return results;
        }
