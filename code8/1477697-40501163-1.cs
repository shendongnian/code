	public class WorkAuthorization
	{
		public string Name { get; set; }
		public string Description { get; set; }
	}
	public partial class Form1 : Form
	{
		private List<WorkAuthorization> workAuthList1;
		private List<WorkAuthorization> workAuthList2;
		public Form1()
		{
			InitializeComponent();
			workAuthList1 = new List<WorkAuthorization>();
			workAuthList1.Add(new WorkAuthorization { Name = "Authorization1", Description = "Description1" });
			workAuthList1.Add(new WorkAuthorization { Name = "Authorization2", Description = "Description2" });
			workAuthList1.Add(new WorkAuthorization { Name = "Authorization3", Description = "Description3" });
			workAuthList2 = new List<WorkAuthorization>();
			workAuthList2.Add(new WorkAuthorization { Name = "Authorization4", Description = "Description4" });
			workAuthList2.Add(new WorkAuthorization { Name = "Authorization5", Description = "Description5" });
			workAuthList2.Add(new WorkAuthorization { Name = "Authorization6", Description = "Description6" });
		}
		private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
		{
			LoadAuthorizations1();
		}
		private void LoadAuthorizations1()
		{
			dataGridView1.DataSource = workAuthList1;
		}
		private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
		{
			LoadAuthorizations2();
		}
		private void LoadAuthorizations2()
		{
			dataGridView2.DataSource = workAuthList2;
		}
		private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			int index = e.RowIndex;
			dataGridView1.DoDragDrop(dataGridView1.Rows[index], DragDropEffects.Move);
		}
		private void dataGridView1_DragEnter(object sender, DragEventArgs e)
		{
			DataGridView otherGridView = (DataGridView)sender;
			if (e.Data.GetDataPresent(typeof(DataGridViewRow)))
			{
				if (!dataGridView1.Rows.Contains((DataGridViewRow)e.Data.GetData(typeof(DataGridViewRow))))
				{
					e.Effect = DragDropEffects.Move;
				}
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}
		private void dataGridView2_DragEnter(object sender, DragEventArgs e)
		{
			DataGridView otherGridView = (DataGridView)sender;
			if (e.Data.GetDataPresent(typeof(DataGridViewRow)))
			{
				if (!dataGridView2.Rows.Contains((DataGridViewRow)e.Data.GetData(typeof(DataGridViewRow))))
				{
					e.Effect = DragDropEffects.Move;
				}
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}
		private void dataGridView2_DragDrop(object sender, DragEventArgs e)
		{
			DataGridViewRow tempRow = (DataGridViewRow)e.Data.GetData(typeof(DataGridViewRow));
			WorkAuthorization tempAuth = new WorkAuthorization();
			tempAuth = (WorkAuthorization)tempRow.DataBoundItem;
			dataGridView2.DataSource = null;
			workAuthList2.Add(tempAuth);
			dataGridView2.DataSource = workAuthList2;
			try
			{
				dataGridView1.DataSource = null;
				workAuthList1.Remove(tempAuth);
				dataGridView1.DataSource = workAuthList1;
			}
			catch
			{
				int index = 0; //For the sake of a break point while debugging
			}
			dataGridView2.Refresh();
			dataGridView1.Refresh();
		}
	}
