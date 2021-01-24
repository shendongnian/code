    protected void GridViewMain_RowDataBound (object Sender, GridViewRowEventArgs Ea) 
    {
        if (Ea.Row.RowType == DataControlRowType.DataRow) 
        {
            string _key = GridView1.DataKeys[Ea.Row.RowIndex].Value.ToString();
            var _nestedGrid = Ea.Row.FindControl ("dgLotDetailsExpand") as GridView;
            if (_nestedGrid == null)
                throw new Exception("NestedGrid's missing...");
    
            _nestedGrid.DataSource = GetNestedData(_key);
            _nestedGrid.DataBind();
        }
    }
    
    private IEnumerable<Detail> GetNestedData (string Lot, string Cont) 
    {
        var _result = new List<Detail> ();
        using (SqlConnection _conn = new SqlConnection (ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString)) 
        {
            _conn.Open ();
            using (var _command = new SqlCommand ("SELECT * FROM lot-details WHERE lot=@lot and Cont=@Cont", _conn)) 
            {
                _command.Parameters.Add (new SqlParameter ("lot", Lot));
                _command.Parameters.Add (new SqlParameter ("Cont", Cont));
    
                using (var _da = new SqlDataAdapter (_command)) 
                {
                    var _dataTable = new DataTable ();
                    _da.Fill (_dataTable);
    
                    foreach (DataRow _aktRow in _dataTable.Rows) 
                    {
                        _result.Add (new Detail () 
                        {
                            Size = _aktRow["Size"].ToString (),
                            Weight = _aktRow["Weight"].ToString (),
                        });
                    }
                }
            }
        }
        return _result;
    }
    
    class Detail {
        public string Size { get; set; }
        public string Weight { get; set; }
    }
