    var strcn = System.Configuration.ConfigurationManager.ConnectionStrings["ConexionDB"].ToString();
    
    using (SqlConnection con = new SqlConnection(strcn))
    {
        con.Open();
        string commandString = @"SELECT  
               B.Nombre as BNombre,G.Nombre as GNombre,D.Nombre as DNombre,B.Precio as BPrecio ,G.Precio as GPrecio,D.Precio as DPrecio,
               B.Gramos as BGramos,G.Gramos as GGramos,D.Gramos as DGramos,B.Tabletas as BTabletas,G.Tabletas as GTabletas,D.Tabletas as DTabletas
           FROM TblBenavides B INNER JOIN TblGuadalajara G ON B.Nombre = G.Nombre 
                               INNER JOIN TblDelAhorro D ON G.Nombre = D.Nombre 
           WHERE B.Nombre='" + TxtMedicamento.Text + "'" +
                 "AND G.Nombre='" + TxtMedicamento.Text + 
                 "' AND D.Nombre='" + TxtMedicamento.Text + "'";
        SqlCommand cmd = new SqlCommand(commandString, con);
        SqlDataReader myReader = cmd.ExecuteReader();
        if (myReader.Read())
        {
            label3.Text = myReader["BNombre"].ToString();
            label4.Text = myReader["GNombre"].ToString();
            label5.Text = myReader["DNombre"].ToString();
            this.label8.Text = myReader["BPrecio"].ToString();
            this.TxtGprecio.Text = myReader["GPrecio"].ToString();
            this.TxtDprecio.Text = myReader["DPrecio"].ToString();
            this.label6.Text = myReader["BGramos"].ToString();
            this.TxtGgramos.Text = myReader["GGramos"].ToString();
            this.TxtDgramos.Text = myReader["DGramos"].ToString();
            this.label7.Text = myReader["BTabletas"].ToString();
            this.TxtGtabletas.Text = myReader["GTabletas"].ToString();
            this.TxtDtabletas.Text = myReader["DTabletas"].ToString();
        }
    }
