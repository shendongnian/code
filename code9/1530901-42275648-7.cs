    public override bool fnSaveNewRecord()
    {
        var database = new SqlDatabase(App_Common._WSFCSConnStr);
        using ( var connection = database.CreateConnection() )
        {
            connection.Open();
            IInsertInformationQuery query = new SqlInserInformationQuery( connection );
            
            query.CodeId = txt_CodeID.Text.Trim();
            query.SubInventoryCode = cbx_SubInventoryCode.Text;
            query.ContactCode = cbx_ContactCode.Text;
            query.CompanyCode = cbx_CompanyCode.Text;
            query.CorgCode = cbx_CorgCode.Text;
            var recordsAffected = query.Execute();
        }
        return base.fnSaveNewRecord();
    }
