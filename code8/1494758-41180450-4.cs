     public void GetSalesItems() //Binding GridView
            {
                    DataSet ds1 = new DataSet();
                    D.id = 2;//SELECT * from DBTABLE
                    ds1 = C.DATA1(D);
                    GvSalesItems.DataSource = ds1.Tables[0];
                    GvSalesItems.DataBind();
                   
            }
