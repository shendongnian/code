    if (objEL.CommandName == "Update_HotelDetails")
                {
                    DataTable dt = SqlHelper.ExecuteDataset("SELECT HotelName, HotelID FROM Master_Hotel WHERE (HotelName = '" + objEL.HotelName + "') AND (HotelID <> '" + objEL.HotelID + "')").Tables[0];
                    if (dt.Rows.Count == 0)
                    {
                        string str = ("UPDATE Master_Hotel SET HotelName = @HotelName, PhoneNo = @PhoneNo, Address = @Address, EmailId = @EmailId, Website = @Website, Image = @Image,ImagePath = @ImagePath WHERE (HotelID = @HotelID)");
    
                        cmd = new SqlCeCommand(str, SqlHelper.objCon);
    
                        cmd.Parameters.Add("@HotelName", SqlDbType.NVarChar).Value = objEL.HotelName;
                        cmd.Parameters.Add("@PhoneNo", SqlDbType.NVarChar).Value = objEL.PhoneNo;
                        cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = objEL.Address;
                        cmd.Parameters.Add("@EmailId", SqlDbType.NVarChar).Value = objEL.EmailId;
                        cmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = objEL.WebSite;
                        cmd.Parameters.Add("@Image", SqlDbType.Image).Value = objEL.BinaryImage;
                        cmd.Parameters.Add("@ImagePath", SqlDbType.NVarChar).Value = objEL.ImagePath;
                        cmd.Parameters.Add("@HotelID", SqlDbType.Int).Value = objEL.HotelID;
                        SqlHelper.objCon.Open();
                        i = cmd.ExecuteNonQuery();
                        SqlHelper.objCon.Close();
                    }
                }
