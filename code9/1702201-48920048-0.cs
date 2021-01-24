         	public class Product_List {
                public string Branch { get; set; }
                public string InvetoryID { get; set; }
                public string Warehouse { get; set; }
                public string Quantity { get; set; }
                public string Unit { get; set; }
              
            }
         public partial class Insert_Detail : Form
            {
                public DataTable Grid_Product = new DataTable();
        		List<Product_List> productlist = new List<Product_List>();
        		 private void Add_Click(object sender, EventArgs e)
                {
                    pcmn.cmn_DT.Clear();
                    Grid_Product.Clear();            
                    
                        
                            productlist.Add(new Product_List
                            {
                                Branch = txt_Branch.Text,
                                InvetoryID =  ddlInvetoryID.SelectedValue.ToString(),
                                Warehouse = ddlWarehouse.SelectedValue.ToString(),
                                Quantity = txt_Quantity.Text,
                                Unit = txt_Unit.Text,
                               
                            });
                        
                    
                    Grid_Product = ToDataTable(productlist);
                                    this.Close();
                }
            }
        	
        	
        	 public partial class SalesOrder : Form
            {
        	 public void AddItem_Click(object sender, EventArgs e)
                {
        	POS_ITEM_Details popup = new POS_ITEM_Details();
                                   
                                    popup.ShowDialog();
                                    foreach (DataRow row in popup.Grid_Product.Rows)
                                    {
        	SalesOrder_Grid.Rows.Add(row["Branch"].ToString(), row["InvetoryID"].ToString(),row["Warehouse"].ToString(),..);
        	}
        	}
    
     public DataTable ToDataTable<T>(List<T> items)
            {
                DataTable dataTable = new DataTable(typeof(T).Name);
                //Get all the properties
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    //Setting column names as Property names
                    dataTable.Columns.Add(prop.Name);
                }
                foreach (T item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {
                        //inserting property values to datatable rows
                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }
                //put a breakpoint here and check datatable
                return dataTable;
            }
