    var success = false;
    var connectionString = @"Data Source=iPC\SQLEXPRESS;Initial Catalog=NML;Integrated Security=True";
    var sql = "INSERT INTO tbl_REC(Qcode,Warp,Ply,Blend,TEnds,Warp1,Weft,[End],Pick,Width,Weave1,Weave2,TL) Values(@Qcode, @Warp, @Ply, @Blend, @TEnds, @Warp1, @Weft, @End, @Pick, @Width, @Weave1, @Weave2, @TL)";
    using(var ABC = new SqlConnection(connectionString))
    {
        using (var command = new SqlCommand(sql, ABC))
        {
            command.Parameters.Add("@Qcode", SqlDbType.NVarChar).Value = textBox2.Text;
            command.Parameters.Add("@Warp", SqlDbType.NVarChar).Value = textBox3.Text;
            command.Parameters.Add("@Ply", SqlDbType.NVarChar).Value = textBox4.Text;
            // ....
            // I'll let you fill in the rest of the parameters...
            // ....
                        
            try
            {
                ABC.Open();
                command.ExecuteNonQuery();
                success = true;
            }
            catch(Exception e)
            {
                // Do something with this exception! write to log, for instance.
            }
        }
    }
    if (success)
    {
        MessageBox.Show("DATA SAVED SUCCESSFULLY");
        textBox2.Clear();
        textBox3.Clear();
        textBox4.Clear();
        textBox5.Clear();
        textBox6.Clear();
        textBox7.Clear();
        textBox8.Clear();
        textBox9.Clear();
        textBox10.Clear();
        textBox11.Clear();
        textBox12.Clear();
        textBox13.Clear();
        textBox14.Clear();
        dateTimePicker1.Value = DateTime.Now;
    }
