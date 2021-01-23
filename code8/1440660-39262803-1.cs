	public partial class RecieveOrder : Form
	{
		DataTable dy;
		reatail r = new reatail();
		public async void storeToStock()
		{
			dy = await Task.Run(() => r.loadAllOrder());
			foreach (DataRow row in dy.Rows)
			{
				MessageBox.Show(row[0].ToString());
			}
		}
	}
