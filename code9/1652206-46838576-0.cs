    if (reader.Read())
            {
                if (!reader.IsDBNull(0))
                    btn.ItemID = (int)reader["ID"];
                if (!reader.IsDBNull(1))
                    btn.ItemName = (string)reader["Name"];
                if (!reader.IsDBNull(2))
                    btn.ItemPrice = (int)reader["Price"];
                if (!reader.IsDBNull(3))
                    btn.ItemDiscount = (float)reader["Discount"];
                btn.Style = (Style)TryFindResource("itemLargeButton");
                itemPanel.Children.Add(btn);
            }   
