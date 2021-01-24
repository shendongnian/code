    using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand("select PartNo,PartDescription,HSN,MRP,GST from products_data", connection);
                adapter.Fill(dataset);
                Dataset products_tbl = dataset.Tables[0];
                //data is AutoCompleteStringCollection object
                for (int i = 0; i < products_tbl.Rows.Count; i++)
                     //You can change the datatype from Decimal to  whatever you want string or etc
                           Decimal h2 = 0;
                          Decimal.TryParse(products_tbl.Rows[i]["PartNo"].ToString(), out h2);
                          data.Add(h2);
            }
