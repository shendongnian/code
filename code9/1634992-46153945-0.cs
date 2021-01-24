    private async void Save()
        {
            OtherField comField = new OtherField
            {
                CreateBy = frmWelcome._User.UserName,
                UpdateBy = frmWelcome._User.UserName
            };
            var orderDetails = new List<OrderDetails>();
            Task<Order> taskFindOrder = new Task<Order>(()=> {
                //details
                foreach (OrderDetailsViewModel item in orderDetailsViewModelBindingSource)
                {
                    OrderDetails details = new OrderDetails
                    {
                        ProductCode = item.ProdCode,
                        BranchStock = item.BRStk,
                        WHStock = item.WHStk,
                        Quantity = item.Quantity
                    };
                    orderDetails.Add(details);
                }
                return con.Orders.FirstOrDefaultAsync(x => x.Number == txtOrderNumber.Text).Result; ;
            });
            taskFindOrder.Start();
            var find = await taskFindOrder;
            if (find != null)
            {
                //run update
                var del = find.Details; //get all previous details
                con.OrderDetails.RemoveRange(del); //addedd this line here to delete
                find.Details = orderDetails; //assign the new value
                find.Others.UpdateBy = frmWelcome._User.UserName;
                find.Others.UpdateTimeStamp = DateTime.Now;
            }
            else
            {
                var order = new Order
                {
                    ID = Guid.NewGuid(),
                    FromLoc = frmWelcome._LocationCode,
                    ToLoc="",
                    Number = txtOrderNumber.Text,
                    Others = comField,
                    Details=orderDetails
                };
                con.Orders.Add(order);
            }
            try
            {
                var result = await con.SaveChangesAsync();
                if (result != 0)
                {
                    new Msg("Successfull", "Record successfully saved.", Msg.MsgType.Success);
                }
                else
                {
                    new Msg("Failed!", "Record failed to save into database.", Msg.MsgType.Warning);
                }
            }
            catch (Exception ex)
            {
                new Msg("Error!", ex.Message, Msg.MsgType.Error);
            }
        }
