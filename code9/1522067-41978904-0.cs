     private void txtCargs_TextChanged(object sender, EventArgs e)
            {
                if (ValidateText())
                {
                    //Then do this
                }
            }
    
            private bool ValidateText()
            {
                bool Isvalidated = false;
    
                try
                {
                    SqlConnection con = new SqlConnection(cs.DBConnP);
                    con.Open();
    
                    string querySelect = @"SELECT RTRIM(CL.Cargs) AS 'Cargs', RTRIM(S.Abvs) AS 'Abss',  RTRIM(CL.Linha) AS 'Linha', RTRIM(CL.Qtd) AS 'Quantity'
                                        FROM CargaCab CC (NOLOCK)
                                        INNER JOIN CargsLin CL (NOLOCK) ON CC.Cargs = CL.Cargs
                                        INNER JOIN Stock S (NOLOCK) ON CL.Code = S.Code 
                                        INNER JOIN Marks M (NOLOCK) ON S.Marks = M.Marks
                                        WHERE CC.Date >= GETDATE() - 120 AND CL.State NOT IN ('F', 'A') AND S.TypeEmb = 'P' 
                                        AND CC.TypeD = 'OCS' AND CL.Cargs = '" + txtCargs.Text.Trim() + "' ORDER BY CL.Carga, S.Marks DESC, S.Abvs";
                    cmd = new SqlCommand(querySelect);
                    cmd.Connection = con;
    
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
    
                    DataSet ds = new DataSet();
                    da.Fill(ds, "CargaCab");
    
                    dataGridView1.DataSource = ds.Tables["CargaCabee"].DefaultView;
    
                    dataGridView1.Columns[0].ReadOnly = true;
                    dataGridView1.Columns[1].ReadOnly = true;
                    dataGridView1.Columns[2].ReadOnly = true;
                    dataGridView1.Columns[3].ReadOnly = false;
    
                    con.Close();
                    Isvalidated = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error\nDetalhes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Isvalidated = false;
                }
    
                return Isvalidated;
            }
