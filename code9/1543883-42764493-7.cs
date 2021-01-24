    Action<IDataReader, MyOrder> action = (r, o) =>
            {
                if (r.IsDBNull(0))
                {
                    o.Shipment = null;
                }
                else
                {
                    o.Shipment = r.GetDateTime(0);
                }
            };
