    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using MySql.Data.MySqlClient;
    
    public partial class Admingroup_Addcar : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    
        private void ExecuteInsert(string id, string carmake, string carmodel, string price, string d_price, string image,
            string quantity, string details, string year, string special)
        {
            var constr = "SERVER=localhost;" +
                         "DATABASE=carsstore;" +
                         "UID=root;" +
                         "PASSWORD=;";
    
            var conn = new MySqlConnection(constr);
    
            var avail = 1;
    
            var sql =
                "INSERT INTO product (id, car_make, car_model, UnitPrice, Discountprice, image, Quantity, availability, details, year, special) VALUES ('" +
                @id + "','" + @carmake + "','" + @carmodel + "','" + @price + "','" + @d_price + "','" + @image + "','" +
                @quantity + "','" + @avail + "','" + @details + "','" + @year + "','" + @special + "');";
    
            try
            {
                conn.Open();
    
                var cmd = new MySqlCommand(sql, conn);
                var param = new MySqlParameter[11];
    
                param[0] = new MySqlParameter("@id", MySqlDbType.VarChar, 4);
                param[1] = new MySqlParameter("@carmake", MySqlDbType.VarChar, 100);
                param[2] = new MySqlParameter("@carmodel", MySqlDbType.VarChar, 100);
                param[3] = new MySqlParameter("@price", MySqlDbType.VarChar, 100);
                param[4] = new MySqlParameter("@d_price", MySqlDbType.VarChar, 100); // put zero if no discount
                param[5] = new MySqlParameter("@image", MySqlDbType.VarChar, 300);
                param[6] = new MySqlParameter("@quantity", MySqlDbType.VarChar, 300);
                param[7] = new MySqlParameter("@avail", MySqlDbType.VarChar, 2);
                param[8] = new MySqlParameter("@details", MySqlDbType.VarChar, 2000);
                param[9] = new MySqlParameter("@year", MySqlDbType.VarChar, 4);
                param[10] = new MySqlParameter("@special", MySqlDbType.VarChar, 2);
    
                param[0].Value = id;
                param[1].Value = carmake;
                param[2].Value = carmodel;
                param[3].Value = price;
                param[4].Value = d_price;
                param[5].Value = image;
                param[6].Value = quantity;
                param[7].Value = avail;
                param[8].Value = details;
                param[9].Value = year;
                param[10].Value = special;
    
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                var msg = "Insert Error:";
                msg += ex.Message;
                throw new Exception(msg);
            }
            finally
            {
                conn.Close();
            }
        }
    
        protected void button_click(object sender, EventArgs e)
        {
            if (price.Text != d_price.Text)
            {
                //call the method to execute insert to the database
                ExecuteInsert(id.Text, carmake.Text,
                    carmodel.Text,
                    price.Text,
                    d_price.Text,
                    image.Text,
                    quantity.SelectedItem.Text,
                    details.Text,
                    year.Text,
                    special.Text
                    );
                Response.Write("Record was successfully added!");
                ClearControls(Page);
            }
            else
            {
                Response.Write("Record Error");
                d_price.Focus();
            }
        }
    
        public static void ClearControls(Control Parent)
        {
            if (Parent is TextBox)
            {
                (Parent as TextBox).Text = string.Empty;
            }
            else
            {
                foreach (Control c in Parent.Controls)
                    ClearControls(c);
            }
        }
    } 
