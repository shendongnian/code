    namespace WindowsFormsApplication
    {
        using System;
        using System.Data;
        using System.Drawing;
        using System.IO;
        using System.Net;
        using System.Windows.Forms;
    
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                dataGridView1.DataSource = GetDataTable();
            }
    
            private DataTable GetDataTable()
            {
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Image", typeof(Image));
    
                // Path to store locally the image
                string imageLocalPath = AppDomain.CurrentDomain.BaseDirectory + "image.ico";
                
                if (File.Exists(imageLocalPath))
                {
                    dataTable.Rows.Add(new object[] { Image.FromFile(imageLocalPath) });                    
                }
                else
                {
                    // Get request to download the image if it does not exist locally
                    var request = WebRequest.Create("http://cdn.sstatic.net/Sites/stackoverflow/img/favicon.ico?v=4f32ecc8f43d");
    
                    using (var response = request.GetResponse())
                    using (var stream = response.GetResponseStream())
                    {
                        // Check if the request is successful
                        if ((response as System.Net.HttpWebResponse).StatusCode == HttpStatusCode.OK)
                        {
                            var image = Bitmap.FromStream(stream);
                            image.Save(imageLocalPath);
    
                            dataTable.Rows.Add(new object[] { image });
                        }
                        // No local image exist and the URL is no longer valid
                        else
                        {
                            // The default Windows Forms image will be displayed
                        }
                    }
                }
    
                return dataTable;
            }
        }
    }
