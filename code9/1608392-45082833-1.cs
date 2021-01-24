     public List<EnEntity> methodname(string pParam1)
        {
            try
            {
                List<EnEntity> ListEntity = new List<EnEntity>();
                SqlCommand cmd = new SqlCommand("sp_name", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@vParam", SqlDbType.VarChar).Value = pParam1;
                
                SqlDataReader drd = cmd.ExecuteReader();
                if (drd.HasRows)//!=null
                {
                    int pos_iIndex = drd.GetOrdinal("iColumnaName");
					while (drd.Read())
                    {
                        EnEntity oEnEntity = new EnEntity();
                        oEnEntity.iPropertie = drd.IsDBNull(pos_iIndex) ? 0 : drd.GetInt32(pos_iIndex);
                        ListEnEntity.Add(oEnEntity);
                    }
                    drd.Close();
                }
                return (ListEnEntity);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
