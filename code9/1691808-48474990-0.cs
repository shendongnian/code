    student.Add(new Item()
                    {
                        ID = dr.GetInt32(dr.GetOrdinal("Id")),
                        itemImage = (byte)dr.GetInt32(dr.GetOrdinal("itemimage")),
                        itemName = dr.GetString(dr.GetOrdinal("itemname")),
                        itemDesc = dr.GetString(dr.GetOrdinal("itemdesc")),
                        itemQuantity = dr.GetInt32(dr.GetOrdinal("qituantity"))
                    });
