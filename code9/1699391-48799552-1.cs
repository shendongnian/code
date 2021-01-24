        private void button2_Click(object sender, EventArgs e)
        {
            string excelstringconn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + textselect.Text + ";Extended Properties=\"Excel 8.0;HDR=Yes;\";";                       
            OleDbConnection conn = new OleDbConnection(excelstringconn);
            bool exist = false;
            if (textselect.Text != "")
            {
                if (textchoice.Text !="")
                {
                    if (comboBox1.SelectedItem == null)
                    {
                        MessageBox.Show("selectioner une matiere !!");
                    }
                    else
                    {
                        //try
                    //{
                        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                        Workbook workbook = excel.Workbooks.Open(textselect.Text);
                        SqlConnection cnn;
                        SqlConnection cn2;
                        SqlConnection cn3;
                        SqlConnection cn4;
                        SqlConnection cn5;
                        string connectionString = null;
                        string sql = null;
                        string sql2 = null;
                        string sql3 = null;
                        string sql4 = null;
                        string sql5 = null;
                        foreach (Worksheet sheet in workbook.Sheets)
                        {
                            if (sheet.Name.Equals(textchoice.Text))
                            {
                                exist = true;
                            }
                        }
                        if (exist == true)
                        {
                            OleDbDataAdapter da = new OleDbDataAdapter("Select * from [" + textchoice.Text + "$]", conn);
                            string numnat = "";
                            string numi="";
                            int notmat =0;
                            int notmat2 =0;
                            da.Fill(dataSet1);
                            //
                            connectionString = @"data source=DESKTOP-NN4Q7KD\MSQLSERVER;initial catalog=et;integrated security=true;";
                            cnn = new SqlConnection(connectionString);
                            cnn.Open();
                            //
                            if (comboBox1.SelectedItem.ToString() == "Mat1") {
                                sql = "SELECT Num_National FROM Mat1 where Num_National=@num";
                                sql2 = "insert into Mat1 (room,fawj,Num_National,Exam_num,num_inscription,Nom_complet,Note_Session_Normal,Note_Session_Rat,Mo) values (@R,@F,@NN,@EN,@NI,@NC,@NSN,@NSR,@M)";
                            }
                            else if (comboBox1.SelectedItem.ToString() == "Mat2")
                            {
                                sql = "SELECT Num_National FROM Mat2 where Num_National=@num";
                                sql2 = "insert into Mat2 (room,fawj,Num_National,Exam_num,num_inscription,Nom_complet,Note_Session_Normal,Note_Session_Rat,Mo) values (@R,@F,@NN,@EN,@NI,@NC,@NSN,@NSR,@M)";
                            }
                            else if (comboBox1.SelectedItem.ToString() == "Mat3")
                            {
                                sql = "SELECT Num_National FROM Mat3 where Num_National=@num";
                                sql2 = "insert into Mat3 (room,fawj,Num_National,Exam_num,num_inscription,Nom_complet,Note_Session_Normal,Note_Session_Rat,Mo) values (@R,@F,@NN,@EN,@NI,@NC,@NSN,@NSR,@M)";
                            }
                            else if (comboBox1.SelectedItem.ToString() == "Mat4")
                            {
                                sql = "SELECT Num_National FROM Mat4 where Num_National=@num";
                                sql2 = "insert into Mat4 (room,fawj,Num_National,Exam_num,num_inscription,Nom_complet,Note_Session_Normal,Note_Session_Rat,Mo) values (@R,@F,@NN,@EN,@NI,@NC,@NSN,@NSR,@M)";
                            }
                            else if (comboBox1.SelectedItem.ToString() == "Mat5")
                            {
                                sql = "SELECT Num_National FROM Mat5 where Num_National=@num";
                                sql2 = "insert into Mat5 (room,fawj,Num_National,Exam_num,num_inscription,Nom_complet,Note_Session_Normal,Note_Session_Rat,Mo) values (@R,@F,@NN,@EN,@NI,@NC,@NSN,@NSR,@M)";
                            }
                            else if (comboBox1.SelectedItem.ToString() == "Mat6")
                            {
                                sql = "SELECT Num_National FROM Mat6 where Num_National=@num";
                                sql2 = "insert into Mat6 (room,fawj,Num_National,Exam_num,num_inscription,Nom_complet,Note_Session_Normal,Note_Session_Rat,Mo) values (@R,@F,@NN,@EN,@NI,@NC,@NSN,@NSR,@M)";
                            }
                            //
                            string p = comboBox1.SelectedItem.ToString();
                            sql3 = "select Num_National from Result where Num_National=@numm";
                            sql4 = "update Result set "+p+"=@nmt";
                            sql5 = "insert into Result values (@FF,@NNN,@NII,@NCC,@MAt1,@MAt2,@MAt3,@MAt4,@MAt5,@MAt6,@total,@Moy,@Res)";
                            SqlDataAdapter DA = new SqlDataAdapter();
                            DA.SelectCommand = new SqlCommand(sql, cnn);
                            for (int i = 0; i <= dataSet1.Tables[0].Rows.Count-1 ;i++ )
                            {
                                DA.SelectCommand.Parameters.Clear();
                                numnat = dataSet1.Tables[0].Rows[i].ItemArray[3].ToString();
                                DA.SelectCommand.Parameters.AddWithValue("@num", numnat);
                                SqlDataReader dr= DA.SelectCommand.ExecuteReader();
                                if (dr.HasRows == true)
                                {
                                    numi = numnat;
                                    MessageBox.Show("User" + numi + "déja exist");
                                    dataSet1.Clear();
                                    break;
                                }
                                else
                                {
                                    //dataGridView1.DataSource = dataSet1.Tables[0];
                                    //ajout Table Matiere
                                    cn2 = new SqlConnection(connectionString);
                                    cn2.Open();
                                    SqlCommand cmd = new SqlCommand(sql2,cn2);
                                    for (int j = 0; j <= dataSet1.Tables[0].Columns.Count-1 ; j++)
                                    {
                                        switch (j)
                                        {
                                            case 1:
                                                string r = dataSet1.Tables[0].Rows[i].ItemArray[j].ToString();
                                                cmd.Parameters.AddWithValue("@R", r);
                                                break;
                                            case 2:
                                                string f = dataSet1.Tables[0].Rows[i].ItemArray[j].ToString();
                                                cmd.Parameters.AddWithValue("@F", f);
                                                break;
                                            case 3:
                                                string nn = dataSet1.Tables[0].Rows[i].ItemArray[j].ToString();
                                                cmd.Parameters.AddWithValue("@NN", nn);
                                                break;
                                            case 4:
                                                string en = dataSet1.Tables[0].Rows[i].ItemArray[j].ToString();
                                                cmd.Parameters.AddWithValue("@EN", en);
                                                break;
                                            case 5:
                                                string ni = dataSet1.Tables[0].Rows[i].ItemArray[j].ToString();
                                                cmd.Parameters.AddWithValue("@NI", ni);
                                                break;
                                            case 6:
                                                string nc = dataSet1.Tables[0].Rows[i].ItemArray[j].ToString();
                                                cmd.Parameters.AddWithValue("@NC", nc);
                                                break;
                                            case 7:
                                                int nsn = int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[j].ToString());
                                                cmd.Parameters.AddWithValue("@NSN", nsn);
                                                break;
                                            case 8:
                                                int nsr = int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[j].ToString());
                                                cmd.Parameters.AddWithValue("@NSR", nsr);
                                                break;
                                            case 9:
                                                string m = dataSet1.Tables[0].Rows[i].ItemArray[j].ToString();
                                                cmd.Parameters.AddWithValue("@M", m);
                                                break;
                                        }
                                        //Ajout Table Result
                                        cn3 = new SqlConnection(connectionString);
                                        cn3.Open();
                                        SqlCommand cm2 = new SqlCommand(sql3, cn3);
                                        cm2.Parameters.AddWithValue("@numm", dataSet1.Tables[0].Rows[i].ItemArray[3].ToString());
                                        SqlDataReader dr2 = cm2.ExecuteReader();
                                        if (dr2.HasRows)
                                        {
                                            cn4 = new SqlConnection(connectionString);
                                            cn4.Open();
                                            SqlCommand cm3 = new SqlCommand(sql4, cn4);
                                            if (int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()) > 10)
                                            {
                                                notmat = int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString());
                                                cm3.Parameters.AddWithValue("@nmt", notmat);
                                            }
                                            else if (int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()) < 10 && int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[8].ToString()) > int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()))
                                            {
                                                notmat = int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[8].ToString());
                                                cm3.Parameters.AddWithValue("@nmt", notmat);
                                            }
                                            else if (int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()) < 10 && int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[8].ToString()) < int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()))
                                            {
                                                notmat = int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString());
                                                cm3.Parameters.AddWithValue("@nmt", notmat);
                                            }
                                            var f = cm3.ExecuteNonQuery();
                                            cm3.Parameters.Clear();
                                        }
                                        else
                                        {
                                            cn5 = new SqlConnection(connectionString);
                                            cn5.Open();
                                            SqlCommand cm4 = new SqlCommand(sql5, cn5);
                                            if(String.IsNullOrEmpty(dataSet1.Tables[0].Rows[i].ItemArray[2].ToString())){
                                                cm4.Parameters.AddWithValue("@FF", DBNull.Value); 
                                            }
                                            else
                                                cm4.Parameters.AddWithValue("@FF", dataSet1.Tables[0].Rows[i].ItemArray[2].ToString());
                                            if(String.IsNullOrEmpty(dataSet1.Tables[0].Rows[i].ItemArray[3].ToString())){
                                                cm4.Parameters.AddWithValue("@NNN", DBNull.Value);
                                            }
                                            else
                                                cm4.Parameters.AddWithValue("@NNN", dataSet1.Tables[0].Rows[i].ItemArray[3].ToString());
                                            if(String.IsNullOrEmpty(dataSet1.Tables[0].Rows[i].ItemArray[5].ToString())){
                                                cm4.Parameters.AddWithValue("@NII", DBNull.Value);
                                            }
                                            else
                                                cm4.Parameters.AddWithValue("@NII", dataSet1.Tables[0].Rows[i].ItemArray[5].ToString());
                                            if (String.IsNullOrEmpty(dataSet1.Tables[0].Rows[i].ItemArray[6].ToString()))
                                            {
                                                cm4.Parameters.AddWithValue("@NCC", DBNull.Value);
                                            }
                                            else
                                                cm4.Parameters.AddWithValue("@NCC", dataSet1.Tables[0].Rows[i].ItemArray[6].ToString());
                                            //
                                            cm4.Parameters.AddWithValue("@total", 5);
                                            cm4.Parameters.AddWithValue("@Moy", 10);
                                            cm4.Parameters.AddWithValue("@Res", "yes");
                                            if (comboBox1.SelectedItem.ToString() == "Mat1") {
                                                if (int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()) > 10)
                                                {
                                                    notmat2 = int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString());
                                                    cm4.Parameters.AddWithValue("@Mat1", notmat2);
                                                }
                                                else if (int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()) < 10 && int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[8].ToString()) > int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()))
                                                {
                                                    notmat = int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[8].ToString());
                                                    cm4.Parameters.AddWithValue("@Mat1", notmat2);
                                                }
                                                else if (int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()) < 10 && int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[8].ToString()) < int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()))
                                                {
                                                    notmat = int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString());
                                                    cm4.Parameters.AddWithValue("@Mat1", notmat2);
                                                }
                                                cm4.Parameters.AddWithValue("@Mat2", DBNull.Value);
                                                cm4.Parameters.AddWithValue("@Mat3", DBNull.Value);
                                                cm4.Parameters.AddWithValue("@Mat4", DBNull.Value);
                                                cm4.Parameters.AddWithValue("@Mat5", DBNull.Value);
                                                cm4.Parameters.AddWithValue("@Mat6", DBNull.Value);
                                            }
                                            else if (comboBox1.SelectedItem.ToString() == "Mat2"){
                                                if (int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()) > 10)
                                                {
                                                    notmat2 = int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString());
                                                    cm4.Parameters.AddWithValue("@Mat2", notmat2);
                                                }
                                                else if (int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()) < 10 && int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[8].ToString()) > int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()))
                                                {
                                                    notmat = int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[8].ToString());
                                                    cm4.Parameters.AddWithValue("@Mat2", notmat2);
                                                }
                                                else if (int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()) < 10 && int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[8].ToString()) < int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()))
                                                {
                                                    notmat = int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString());
                                                    cm4.Parameters.AddWithValue("@Mat2", notmat2);
                                                }
                                                cm4.Parameters.AddWithValue("@Mat1", DBNull.Value);
                                                cm4.Parameters.AddWithValue("@Mat3", DBNull.Value);
                                                cm4.Parameters.AddWithValue("@Mat4", DBNull.Value);
                                                cm4.Parameters.AddWithValue("@Mat5", DBNull.Value);
                                                cm4.Parameters.AddWithValue("@Mat6", DBNull.Value);
                                            }
                                            else if (comboBox1.SelectedItem.ToString() == "Mat3"){
                                                if (int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()) > 10)
                                                {
                                                    notmat2 = int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString());
                                                    cm4.Parameters.AddWithValue("@Mat3", notmat2);
                                                }
                                                else if (int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()) < 10 && int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[8].ToString()) > int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()))
                                                {
                                                    notmat = int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[8].ToString());
                                                    cm4.Parameters.AddWithValue("@Mat3", notmat2);
                                                }
                                                else if (int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()) < 10 && int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[8].ToString()) < int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()))
                                                {
                                                    notmat = int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString());
                                                    cm4.Parameters.AddWithValue("@Mat3", notmat2);
                                                }
                                                cm4.Parameters.AddWithValue("@Mat1", DBNull.Value);
                                                cm4.Parameters.AddWithValue("@Mat2", DBNull.Value);
                                                cm4.Parameters.AddWithValue("@Mat4", DBNull.Value);
                                                cm4.Parameters.AddWithValue("@Mat5", DBNull.Value);
                                                cm4.Parameters.AddWithValue("@Mat6", DBNull.Value);
                                            }
                                            else if (comboBox1.SelectedItem.ToString() == "Mat4"){
                                                if (int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()) > 10)
                                                {
                                                    notmat2 = int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString());
                                                    cm4.Parameters.AddWithValue("@Mat4", notmat2);
                                                }
                                                else if (int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()) < 10 && int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[8].ToString()) > int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()))
                                                {
                                                    notmat = int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[8].ToString());
                                                    cm4.Parameters.AddWithValue("@Mat4", notmat2);
                                                }
                                                else if (int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()) < 10 && int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[8].ToString()) < int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()))
                                                {
                                                    notmat = int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString());
                                                    cm4.Parameters.AddWithValue("@Mat4", notmat2);
                                                }
                                                cm4.Parameters.AddWithValue("@Mat1", DBNull.Value);
                                                cm4.Parameters.AddWithValue("@Mat2", DBNull.Value);
                                                cm4.Parameters.AddWithValue("@Mat3", DBNull.Value);
                                                cm4.Parameters.AddWithValue("@Mat5", DBNull.Value);
                                                cm4.Parameters.AddWithValue("@Mat6", DBNull.Value);
                                            }
                                            else if (comboBox1.SelectedItem.ToString() == "Mat5"){
                                                if (int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()) > 10)
                                                {
                                                    notmat2 = int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString());
                                                    cm4.Parameters.AddWithValue("@Mat5", notmat2);
                                                }
                                                else if (int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()) < 10 && int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[8].ToString()) > int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()))
                                                {
                                                    notmat = int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[8].ToString());
                                                    cm4.Parameters.AddWithValue("@Mat5", notmat2);
                                                }
                                                else if (int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()) < 10 && int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[8].ToString()) < int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()))
                                                {
                                                    notmat = int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString());
                                                    cm4.Parameters.AddWithValue("@Mat5", notmat2);
                                                }
                                                cm4.Parameters.AddWithValue("@Mat1", DBNull.Value);
                                                cm4.Parameters.AddWithValue("@Mat2", DBNull.Value);
                                                cm4.Parameters.AddWithValue("@Mat3", DBNull.Value);
                                                cm4.Parameters.AddWithValue("@Mat4", DBNull.Value);
                                                cm4.Parameters.AddWithValue("@Mat6", DBNull.Value);
                                            }
                                            else if (comboBox1.SelectedItem.ToString() == "Mat6"){
                                                if (int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()) > 10)
                                                {
                                                    notmat2 = int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString());
                                                    cm4.Parameters.AddWithValue("@Mat6", notmat2);
                                                }
                                                else if (int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()) < 10 && int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[8].ToString()) > int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()))
                                                {
                                                    notmat = int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[8].ToString());
                                                    cm4.Parameters.AddWithValue("@Mat6", notmat2);
                                                }
                                                else if (int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()) < 10 && int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[8].ToString()) < int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString()))
                                                {
                                                    notmat = int.Parse(dataSet1.Tables[0].Rows[i].ItemArray[7].ToString());
                                                    cm4.Parameters.AddWithValue("@Mat6", notmat2);
                                                }
                                                cm4.Parameters.AddWithValue("@Mat1", DBNull.Value);
                                                cm4.Parameters.AddWithValue("@Mat2", DBNull.Value);
                                                cm4.Parameters.AddWithValue("@Mat3", DBNull.Value);
                                                cm4.Parameters.AddWithValue("@Mat4", DBNull.Value);
                                                cm4.Parameters.AddWithValue("@Mat5", DBNull.Value);
                                            }
                                            var rows = cm4.ExecuteNonQuery();
                                            cm4.Parameters.Clear();
                                            cm2.Parameters.Clear();
                                        }
                                        //
                                    }
                                    var rowAffected = cmd.ExecuteNonQuery();
                                    MessageBox.Show(rowAffected+"ligne efectuéss");
                                    cmd.Parameters.Clear();
                                }
                                dr.Close();
                            }
                            dataSet1.Clear();
                        }
                        else
                            MessageBox.Show("entrez une sheet valide");
                    //}
                    //catch
                    //{
                    //}
                    }
                }
                else
                    MessageBox.Show("champs vide");
            }
            else
                MessageBox.Show("Selectioner un fichier");
        }
