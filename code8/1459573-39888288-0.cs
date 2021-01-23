        public IEnumerable<classfile> GetData(bool isactive)
        {
            using (SqlConnection cnn = this.OpenConnection())
            {
                 DynamicParameters parameters = new DynamicParameters();
                 parameters.Add("@isActive", isactive);
                 IList<classfile> SampleList = SqlMapper.Query<classfile>(cnn, "SPName", parameters, commandType: CommandType.StoredProcedure).ToList();
                cnn.Close();
                return SampleList.ToList();
            }
        }
