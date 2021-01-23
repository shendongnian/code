	public class reatail
	{
		public DataTable loadAllOrder()
		{
			DataTable order_dt = new DataTable();
			OleDbConnection co = new OleDbConnection();
			co.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sd + "bowoni.accdb";
			string loadAll = "select * from allorder";
			co.Open();
			OleDbCommand cc = new OleDbCommand(loadAll, co);
			OleDbDataAdapter ad = new OleDbDataAdapter(cc);
			ad.Fill(order_dt);
			return order_dt;
		}
	}
	
	public partial class RecieveOrder : Form
	{
		DataTable dy;
		reatail r = new reatail();
		public void storeToStock()
		{
			Task
				.Run(() => r.loadAllOrder())
				.ContinueWith(t =>
				{
					dy = t.Result;
					foreach (DataRow row in dy.Rows)
					{
						MessageBox.Show(row[0].ToString());
					}
				}, TaskScheduler.FromCurrentSynchronizationContext());
		}
	}
