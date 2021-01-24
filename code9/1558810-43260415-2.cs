    protected void GenerateBill(int enquiryId)
    {
        string companyName = "Dream Holidays";
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;
            AttachDbFilename=D:\PROJECT SEM6\Online Tours and Travels\App_Data\ToursandTravels.mdf;
            Integrated Security=True;User Instance=True");
        
        SqlCommand cmd = new SqlCommand("SELECT E.[enquiryid],E.[packname],
            E.[name],E.[mobileno],E.[email],P.[packageprice] 
            FROM [enquiry] E INNER JOIN package P ON E.[packname]=P.[packname] 
            WHERE E.[enquiryId] = @enquiryId");
        
        SqlDataAdapter sda = new SqlDataAdapter();
        cmd.Connection = con;
        cmd.Parameters.Add(new SqlParameter("@enquiryId", enquiryId));
        sda.SelectCommand = cmd;
        DataTable dt = new DataTable();
        sda.Fill(dt);
        // Rest of the code of printing PDF
    }
