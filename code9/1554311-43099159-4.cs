    using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Linq;
	using System.Text;
	using System.Windows.Forms;
	using System.Collections.Specialized;
	using System.Net;
	namespace WindowsFormsApplication1
	{
		public partial class Form1 : Form
	    {
	    public Form1()
	        {
	        InitializeComponent();
	        }
	    	private void button1_Click(object sender, EventArgs e)
	        {
	        using (var client = new WebClient())
	            {
	            var postData = new NameValueCollection();
	            postData["user"] = "Foo";
	            postData["password"] = "Baz";
	            var response = client.UploadValues("http://localhost/xxx.php", postData);
	            var data = Encoding.Default.GetString(response);
	            // Console.WriteLine("Data from server: " + data);
	            MessageBox.Show(data);
	            }
	        }
	    }
	}
