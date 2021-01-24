        private class Product
        {
            public string Productid { get; set; }
            public decimal Piece { get; set; }
            public decimal Price { get; set; }
            // TODO: Add name etc...
        }
        protected void BtnCompleteOrder_Click(object sender, EventArgs e)
        {
            var products = new Dictionary<string, Product>();
            foreach (RepeaterItem item in Repeater1.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    Label lblproductid = (Label)item.FindControl("LblProductID");
                    Image imgproductimage = (Image)item.FindControl("ImgProductImage");
                    Label lblproductname = (Label)item.FindControl("LblProductName");
                    Label lblprice = (Label)item.FindControl("LblPrice");
                    Label lblpiece = (Label)item.FindControl("LblPiece");
                    var currentProductid = lblproductid.Text;
                    var currentPiece = Convert.ToDecimal(lblpiece);
                    if (products.ContainsKey(currentProductid))
                    {
                        products[currentProductid].Piece += currentPiece;
                    }
                    else
                    {
                        products.Add(currentProductid, new Product
                        {
                            Piece=currentPiece,
                        }
                        );
                    }
                }
                foreach (var currentProduct in products.Values)
                {
                    function.cmd("INSERT INTO tbl_Order(userid, productid, name, surname, email, identificationnumber, phone, productimage, productname, piece, cargo, totalprice, paymenttype, orderdate) VALUES('" + Session["userid"] + "', '" 
                        + currentProduct.Productid
                        
                        
                        //TODO change all below etc....
                        + "', '" + Session["name"] + "', '" + Session["surname"] + "', '" + Session["email"] + "', '" + Session["identificationnumber"] + "', '" + Session["phone"] + "', '" + imgproductimage.ImageUrl + "', '" + lblproductname.Text + "', '" + lblpiece.Text + "', '" + Session["cargo"] + "', '" + LblTotalPrice.Text + "', '" + DrpDwnPaymentType.Text + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')");
                }
            }
        }
