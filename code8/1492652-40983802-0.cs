     using System;
     using System.Collections.Generic;
     using System.ComponentModel;
     using System.Data;
     using System.Drawing;
     using System.IO;
     using System.Linq;
     using System.Text;
     using System.Windows.Forms;
     namespace SmallStore
    {
        public partial class AddProduct : Form
    {
        private db_Entities db = new db_Entities();
        private Byte[] byteBLOBData;
      
        public AddProduct()
        {
            InitializeComponent();
            comboCatagory.DataSource = db.Product_Type.ToList();
            comboCatagory.DisplayMember = "Product_Type";
            comboCatagory.ValueMember = "Description";
            comboCatagory.Invalidate();
            
        }
        private void AddProduct_Load(object sender, EventArgs e)
        {
            //check the data type cant cast to int dont know why
            //MessageBox.Show(db.Product_Type.ToList().GetType().ToString());
        }
        private void btnUpload_Click(object sender, EventArgs e)
        {
           
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileStream fsBLOBFile = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                byteBLOBData = new Byte[fsBLOBFile.Length];
                fsBLOBFile.Read(byteBLOBData, 0, byteBLOBData.Length);
                MemoryStream memBLOBData = new MemoryStream(byteBLOBData);
                pictureBox1.Image = Image.FromStream(memBLOBData);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            
            product.Description = txtDescription.Text;
            
            product.Price = decimal.Parse(txtPrice.Text);
            product.Image = byteBLOBData;
            /*this is the line in question*/
            product.ProductType = (int)(comboCatagory.SelectedValue);
            
            db.Products.Add(product);
            
            db.SaveChanges();
        }
    }
}
