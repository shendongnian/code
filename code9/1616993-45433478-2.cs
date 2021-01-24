      protected void OnUpdate(object sender, EventArgs e)
    {
        string StrConnString = ConfigurationManager.ConnectionStrings["BenzConnectionString"].ToString();
        SqlConnection objConn = new SqlConnection(StrConnString);
    
        try
        {
    
            objConn.Open();
    
            using(SqlCommand objCmd1 = new SqlCommand("UPDATE  Employee SET FirstName =  @sFirstName," +
                " LastName = @sLastName," +
                " EMail = @sEMail, " +
                "PhoneNo = @sPhoneNo, " +
                "PositionID = @sPositionID, " +
                "DepartmentID = @sDepartmentID" +
                " WHERE  EmployeeID = @sEmployeeID", objConn){
    
            objCmd.Parameters.AddWithValue("@sFirstName", txtfirstname.Text);
            objCmd.Parameters.AddWithValue("@sLastName", txtlastname.Text);
            objCmd.Parameters.AddWithValue("@sEMail", txtemail.Text);
            objCmd.Parameters.AddWithValue("@sPhoneNo", txtphone.Text);
            objCmd.Parameters.AddWithValue("@sPositionID", dpposition.Text);
            objCmd.Parameters.AddWithValue("@sDepartmentID", dpcenter.Text);
            objCmd.Parameters.AddWithValue("@sEmployeeID", empno);
    
            objCmd.ExecuteNonQuery();
    }
    
            using(SqlCommand objCmd2 = new SqlCommand("UPDATE Item SET Brand = @sBrand, " +
                "Model = @sModel, " +
                "Serial_No = @sSerial_No, " +
                "Macaddress = @sMacaddress, " +
                "ItemTypeID = @sItemTypeID, " +
                "ReceiveDate = @sReceiveDate  " +
                "WHERE ItemID = @sItemID ", objConn){
    
            objCmd.Parameters.AddWithValue("@sBrand", txtbrand.Text);
            objCmd.Parameters.AddWithValue("@sModel", txtmodel.Text);
            objCmd.Parameters.AddWithValue("@sSerial_No", txtserial.Text);
            objCmd.Parameters.AddWithValue("@sMacaddress", txtmac.Text);
            objCmd.Parameters.AddWithValue("@sItemTypeID", dptype.Text);
            objCmd.Parameters.AddWithValue("@sReceiveDate", txtreceiveddate.Text);
            objCmd.Parameters.AddWithValue("@sItemID", itemid);
    
    
            objCmd = new SqlCommand("UPDATE SET InventoryLine SET Transaction_date = @sTransaction_date," +
                " ReturnDate = @sReturnDate " +
                "WHERE InventoryID = @sInventoryID", objConn);
            objCmd.Parameters.AddWithValue("@sReturnDate", txtreturndate.Text);
            objCmd.Parameters.AddWithValue("@sTransaction_date", txtreturndate.Text);
            objCmd.Parameters.AddWithValue("@sInventoryID", inventoryid);
            objCmd.ExecuteNonQuery();
    }
        }
        catch (Exception ex)
        {
            Response.Write("<br/> Error : " + ex.Message);
        }
        finally
        {
            objConn.Close();
        }
    }
