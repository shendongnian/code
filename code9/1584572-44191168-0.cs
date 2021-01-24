    using (var context =new FactorEntities())
                    {
                       var CustomerDetaile= context.tblCustomers.Find(CustomerID);
                       CustomerDetaile.CustomerID = CustomerID;
                       if (!string.IsNullOrWhiteSpace(TxtCustomerName.Text))
                       {
                           CustomerDetaile.CustomerName = TxtCustomerName.Text;
                           
                       }
                      
                      
                       CustomerDetaile.CustomerLastName = TxtLastName.Text;
                       CustomerDetaile.CustomerAdresse = TxtCustomerAdress.Text;
                       CustomerDetaile.CustomerCellPhone = Convert.ToInt32(TxtCustomerCellphone.Text);
                       CustomerDetaile.CustomerCode = Convert.ToInt32(TxtCustomerCode.Text);
                       context.SaveChanges();
                    }
