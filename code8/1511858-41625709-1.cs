    public List<Order> AllOrders()
            {
                DataTable Table = new DataTable();
                List<Order> Orders = new List<Order>();
                Table = Browse(1, 0);
                foreach (DataRow Row in Table.Rows)
                {
                    Order item = new Order();
    
                    item.ID = (int)Row[0];
                    item.Date = (DateTime)Row[1];
                    item.Products = new List<Accessoire>();
                    item.Products = Accessoires((int)Row[0]); <=== Modified here 
                    item.Client = new Gestion.Garage.Modules._Client();
                    item.TotalPrice = (string)Row[3];
                    item.Client.ID = (int)Row[2];
                    item.Client.Name = (string)Row[9];
                    item.Client.Phone = (string)Row[10];
                    item.Client.Email = (string)Row[11];
                    item.Client.Adress = (string)Row[12];
                    item.Client.Marque = (string)Row[13];
                    item.Client.Model = (string)Row[14];
                    item.Client.Kilometrage = (string)Row[15];
                    item.Client.Anne = (string)Row[16];
                    item.Client.Obvservation = (string)Row[17];
                    item.AcessoireID = (int)Row[18];
                    if (!Orders.Contains(item))
                    {
                        Orders.Add(item);
                    }
                }
    
                return Orders;
            }
