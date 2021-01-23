    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace Samples
    {
    	public class Master
    	{
    		public string Name { get; set; }
    		public ICollection<Detail> Details { get; set; }
    	}
    
    	public class Detail
    	{
    		public string Name { get; set; }
    	}
    
    	static class Program
    	{
    		[STAThread]
    		static void Main()
    		{
    			Application.EnableVisualStyles();
    			Application.SetCompatibleTextRenderingDefault(false);
    			var form = new Form();
    			var split = new SplitContainer { Dock = DockStyle.Fill, Parent = form, Orientation = Orientation.Horizontal };
    			var dgvMaster = new DataGridView { Dock = DockStyle.Fill, Parent = split.Panel1 };
    			var dgvDetail = new DataGridView { Dock = DockStyle.Fill, Parent = split.Panel2 };
    			var data = Enumerable.Range(1, 10).Select(p => new Master
    			{
    				Name = "P" + p,
    				Details = Enumerable.Range(1, 10).Select(c => new Detail
    				{
    					Name = "C" + p + "." + c,
    				}).ToList()
    			}).ToList();
    
    			var bsMaster = new BindingSource { DataSource = data };
    			dgvMaster.DataSource = bsMaster;
    			dgvDetail.DataBindings.Add("DataSource", bsMaster, "Details", true, DataSourceUpdateMode.Never);
    
    			Application.Run(form);
    		}
    	}
    }
