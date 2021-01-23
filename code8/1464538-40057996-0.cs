    new Thread(GetInfo).Start();
    
    
    public void GetInfo()
    {
        while (true)
        {
            if (SellerControlGroup.Enabled)
            {
                SqlDataReader Type = new SqlCommand("select type from _Price where Service = 1", sqlCon.con).ExecuteReader();
                while (Type.Read())
                {
                    string type = Convert.ToString(Type["type"]);
                    
                    // Update control with the same thread its been created
                    this.Invoke((MethodInvoker)delegate()
                    {
                      ProgramType.Items.Add(type);
                    });
                }
                Type.Close();
            }
        }
    }
