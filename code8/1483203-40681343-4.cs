    Protected Sub Populate_Activity2_DDL(ByVal selOne As Integer)
    Dim strProcName As String = "usp_Get2ndLevelList"
    Dim connSQL As New SqlConnection
    Dim cmd As SqlCommand
    connSQL.ConnectionString = ConfigurationManager.ConnectionStrings("ThisDBsConnectionString").ToString
    cmd = New SqlCommand(strProcName, connSQL)
    cmd.CommandType = CommandType.StoredProcedure
    cmd.Parameters.AddWithValue("ActTypeID", selOne)
    cmd.Connection.Open()
       'dd_AT2_Values means drop-down list activity type 2 values'
    Dim ddl_AT2_Values As SqlDataReader
    ddl_AT2_Values = cmd.ExecuteReader()
    If ddl_AT2_Values.HasRows = False Then
        ddlAct2Type.Visible = False
        lblSpecs.Visible = False
        cmd.Connection.Close()
        cmd.Connection.Dispose()
        Exit Sub
    End If
    ddlAct2Type.DataSource = ddl_AT2_Values
    ddlAct2Type.DataValueField = "Ac2Type_ID"
    ddlAct2Type.DataTextField = "Ac2T_Name"
    ddlAct2Type.DataBind()
    ddlAct2Type.Items.Insert(0, New ListItem(String.Empty, String.Empty))
    ddlAct2Type.SelectedIndex = 0
    cmd.Connection.Close()
    cmd.Connection.Dispose()
            End If
    End Sub
