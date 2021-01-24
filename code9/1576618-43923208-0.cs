    using System;
	using System.Drawing;
	using System.Windows.Forms;
	using System.Threading;
	using System.ComponentModel;
	
	namespace MouseMatchMoving
	{
		public partial class Form1 : Form
		{
			public Form1()
			{
				InitializeComponent();
				// These are the event handling functions
				label1.MouseDown += new MouseEventHandler(Label_Mouse_Down);
				label1.MouseMove += new MouseEventHandler(Label_Mouse_Move);
				label1.MouseUp += new MouseEventHandler(Label_Mouse_Up);
				listBox1.MouseWheel += new MouseEventHandler(List_Mouse_Scroll);
				listBox1.MouseMove += new MouseEventHandler(List_Mouse_Move);
				listBox1.MouseDown += new MouseEventHandler(List_Mouse_Down);
				backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(BProgress);
				backgroundWorker1.DoWork += new DoWorkEventHandler(BDowork);
				backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BWCompleted);
				backgroundWorker1.WorkerReportsProgress = true;
				// Start the backgroundworker
				backgroundWorker1.RunWorkerAsync();
				label1.BringToFront();
			}
			
			Rectangle IndexLocation;
			private Point MouseDownLocation;
	
			// Form loading
			private void Form1_Load(object sender, EventArgs e)
			{
				for (int x = 0; x < 40; x++)
				{
					listBox1.Items.Add("This is new text");
				}
				listBox1.SelectedIndex = 0;
			}
			
			// This backgroundworker invokes the GUI thread
			private void BDowork(object sender, DoWorkEventArgs e)
			{
				if (InvokeRequired)
				{
					this.Invoke(new Action(() => List_Function()));
					return;
				}
			}
	
			private void BProgress(object sender, ProgressChangedEventArgs e)
			{
				label1.Text = e.ProgressPercentage.ToString();
				Console.WriteLine(e.ProgressPercentage.ToString());
				Console.WriteLine(e.UserState);
			}
			
			private void BWCompleted(object sender, RunWorkerCompletedEventArgs e)
			{
				Console.WriteLine(e.Cancelled);
			}
	
			// This begins the mouse ListBox Focus functions
			private void List_Mouse_Down(object sender, MouseEventArgs e)
			{
				if (e.Button == MouseButtons.Left)
				{
					List_Function();
				}
			}
			
			public void List_Mouse_Move(object sender, MouseEventArgs e)
			{
				if (MouseButtons == MouseButtons.Left)
				{
					List_Function();
				}
			}
	
			// This is the mouse scrolling function which calls the backgroundworker
			public void List_Mouse_Scroll(object sender, MouseEventArgs e)
			{
				listBox1.SetSelected(listBox1.SelectedIndex, true);
				listBox1.GetSelected(listBox1.SelectedIndex);
				backgroundWorker1.RunWorkerAsync();
			}
			
			// This is invokes the draggable label mouse functions
			private void Label_Mouse_Down(object sender, MouseEventArgs e)
			{
				if (e.Button == MouseButtons.Left)
				{
					MouseDownLocation = e.Location;
				}
			}
	
			private void Label_Mouse_Move(object sender, MouseEventArgs e)
			{
				if (e.Button == MouseButtons.Left)
				{
					Point start = Point.Empty;
					int nx = Math.Min(Math.Max(label1.Left - MouseDownLocation.X + (e.X - start.X), 0), label1.Parent.Width - label1.Width);
					int ny = Math.Min(Math.Max(label1.Top - MouseDownLocation.Y + (e.Y - start.Y), 0), label1.Parent.Height - label1.Height);
					label1.Location = new Point(nx, ny);
				}
			}
	
			private void Label_Mouse_Up(object sender, MouseEventArgs e)
			{
				MouseDownLocation = e.Location;
			}
			
			// This is the mouse list tracking function
			public void List_Function()
			{
				label1.Text = listBox1.SelectedIndex.ToString();
				IndexLocation = listBox1.GetItemRectangle(listBox1.SelectedIndex);
				int nx = Convert.ToInt32(IndexLocation.X);
				int ny = Convert.ToInt32(IndexLocation.Y);
				label1.Location = new Point(nx, ny);
				textBox1.Text = listBox1.GetItemRectangle(listBox1.SelectedIndex).ToString();
				Console.WriteLine(listBox1.GetItemRectangle(listBox1.SelectedIndex));
			}
		}
	}
