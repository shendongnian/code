    protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CustID"] != null)
            {
                int CID = (int)Session["CustID"];
                using (var myEntities = new Entities())
                {
                    var CustName = (from customer in myEntities.Customer
                                    where customer.CustomerId == (CID)
                                    select customer.Name).SingleOrDefault();
                    if (CustName == null) // error handling if customer name does not exist
                        throw new Exception("No such Customer found.");
                    lblName.ForeColor = Color.Red;
                    lblName.Text = CustName;
                }
            }
            if (Session["newOrderID"] != null)
            {
                int OID = (int)Session["CustID"];
                using (var myEntities = new Entities())
                {
                    var OrderNum = (from order in myEntities.Orders
                                    where order.OrderId == (OID)
                                    select order.OrderId).SingleOrDefault();
                    if (OrderNum == 0) // error handling if customer name does not exist
                        throw new Exception("No such Order found.");
                    lblOrderID.ForeColor = Color.Red;
                    lblOrderID.Text = OrderNum.ToString();
                }
            }
            DateTime date = DateTime.Now;
            DateTime DeliveryDate = date.AddDays(5);
            lblDate.ForeColor = Color.Red;
            lblDeliveryDate.ForeColor = Color.Red;
            lblDate.Text = date.ToLongDateString();
            lblDeliveryDate.Text = DeliveryDate.ToLongDateString();
        }
