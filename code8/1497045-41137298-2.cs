    public void FillValues(Form form, string UserName)
    {
       DataTable DT;
       SqlCommand cmd = new SqlCommand();
       try
       {
           cmd.Connection = Connections.Connection[UserName];
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.CommandText = "TrainerMaster_pro";
           cmd.Parameters.AddWithValue("Option", "FillValues".Trim());
           if (Connections.Connection[UserName].State == ConnectionState.Closed)
                Connections.Connection[UserName].Open();
           SqlDataAdapter adp = new SqlDataAdapter(cmd);
           DT = new DataTable();
           adp.Fill(DT);                
           form.lblId___.Text = DT.Rows[0][0].ToString();
         }
         catch (Exception ex)
         {
           MessageBox.Show(ex.ToString());
         }
         finally
         {
           cmd.Parameters.Clear();
           cmd.Dispose();
           Connections.Connection[UserName].Close();                
         }
             
         Type tp = Type.GetType("HealthClub." + form.Name);
         object myobj = Activator.CreateInstance(tp);
         MethodInfo method = myobj.GetType().GetMethod("FillValues");   
         object[] parametersArray = new object[] { UserName };
         form.Refresh();
        }
    }
