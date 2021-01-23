    private void AgregarFila()
    {
        if (Session["miTabla"] == null) //New table, create table and save it with the new record in Session variable
        {
            dt.Columns.Add("Fecha", typeof(String));
            dt.Columns.Add("Documento", typeof(String));
            dt.Columns.Add("Folio", typeof(Int32));
            dtRow = dt.NewRow();
            dtRow["Fecha"] = Session["HCfecha"];
            dtRow["Documento"] = Session["HCDocumento"];
            dtRow["Folio"] = Session["HCFolio"];
            dt.Rows.Add(dtRow);
            Session["miTabla"] = dt;
        }
       else
        {
            dt = (DataTable) Session["miTabla"]; //Read Session variable
            for (int i = 0; i <= 2; i++)
            {
               dtRow = dt.NewRow();
               dtRow["Fecha"] = Session["HCfecha"];
               dtRow["Documento"] = Session["HCDocumento"];
               dtRow["Folio"] = Session["HCFolio"];
               dt.Rows.Add(dtRow);
            }
            Session["miTabla"] = dt;   //Write Session variable after record added     
       }
        gvHistoriaLaboral.DataSource = dt;
        gvHistoriaLaboral.DataBind();
    }
