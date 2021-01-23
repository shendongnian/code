    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Data.OleDb;
    public class frmDatabase
    {
	OleDbConnection con = new OleDbConnection();
	DataSet ds = new DataSet();
	DataTable dt = new DataTable();
	OleDbDataAdapter da = new OleDbDataAdapter();
	private void frmProject_Load(object sender, EventArgs e)
	{
		con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\xxx\\xxx\\xxx.mdb";
		con.Open();
		ds.Tables.Add(dt);
		da = new OleDbDataAdapter("Select * from table", con);
		da.Fill(dt);
		dgvDetails.DataSource = dt.DefaultView;
		con.Close();
	}
	private void cmdUpdate_Click(object sender, EventArgs e)
	{
		con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\xxx\\xxx\\xxx.mdb";
		con.Open();
		ds.Tables.Add(dt);
		da = new OleDbDataAdapter("Select * from table", con);
		da.Update(dt);
		con.Close();
	}
	public frmDatabase()
	{
		Load += frmProject_Load;
	}
    }
