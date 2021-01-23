                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add((new SqlParameter("@Data", value) { SqlDbType = System.Data.SqlDbType.VarBinary }));
                parametros.Add((new SqlParameter("@KeyValue", key) { SqlDbType = System.Data.SqlDbType.VarChar }));
                String v = null;
                v = this.Database.SqlQuery<String>("SELECT SEGURIDAD.FN_Get_DecryptionData(@Data,@KeyValue)", parametros.ToArray()).FirstOrDefault();
                decryptedValue = v;
            }
            catch (Exception ex)
            {
            }
