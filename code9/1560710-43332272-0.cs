    public DataTable GetHotelReportData(int _ratpropid) {
            var _connectionString = _isDevelopment ? CommonTypes.Dev : CommonTypes.Prod;
            DataTable dt = new DataTable();
            dt.Clear();
            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("ww.HotelRpt_spGenerateData2018", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RatPropId", _ratpropid);
            try {
                conn.Open();
                dt.Load(cmd.ExecuteReader);
                return dt;
            }
            catch (Exception _ex) {
                new ErrorLogging().Log(_ex);
            }
            finally {
                conn.Close();
                cmd.Dispose();
            }
        }
