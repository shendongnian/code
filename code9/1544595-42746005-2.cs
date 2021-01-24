    protected void Button1_Click(object sender, EventArgs e)
    {
        Lab25WebServiceSoapClient obj = new Lab25WebServiceSoapClient();
        DataTable vDt = obj.GetAllEmployeesFromEmp();
        GridView1.DataSource = vDt;
        GridView1.DataBind();
    }
