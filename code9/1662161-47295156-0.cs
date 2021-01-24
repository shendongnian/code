    string _cmd = "SELECT razao_social FROM tblImobiliarias WHERE cnpj ='" + ValorConsulta.Text + "'";
                        string conn = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=\\\\10.7.41.153\\Apoio\\Davi_Database\\Base_Imo.accdb";
                        OleDbConnection Connection = new OleDbConnection(conn);
                        OleDbCommand Command = new OleDbCommand(_cmd, Connection);
                        Connection.Open();
                        OleDbDataReader reader = Command.ExecuteReader();
                        while (reader.Read())
                        {
                            int _resMatriz = 0;
                            DialogResult result;
                            result = MessageBox.Show("Encontrado imobiliária: " + reader[_resMatriz] + ".\nEstá correto?", "Pesquisa", MessageBoxButtons.YesNo);
                            _resMatriz++;
                            if (result == System.Windows.Forms.DialogResult.Yes)
                            {
                                MessageBox.Show("CarregaImo()");
                                break;
                            }
                            else
                            {
                                continue;
                            } 
                        }
