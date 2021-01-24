    string mySqlCon = "Server = localhost; port = 3306; database = rmsdb; Uid = root; pwd=''"; //connection string
    private void loginbtn_Click(object sender, EventArgs e)
    {
        var succeeded = false;
        var canUpdate = firstnametb.Text.Length > 0
            && lastnametb.Text.Length > 0
            && gendercb.Text.Length > 0
            && addresstb.Text.Length > 0
            && birthdatetb.Text.Length > 0
            && gradelevelcb.Text.Length > 0
            && sectioncb.Text.Length > 0
            && positioncb.Text.Length > 0
            && empstatuscb.Text.Length > 0
            && fiutb.Text.Length > 0
            && oadtb.Text.Length > 0
            && prctb.Text.Length > 0
            && gsistb.Text.Length > 0
            && csetb.Text.Length > 0
            && contacttb.Text.Length > 0
            && usernametb.Text.Length > 0
            && passwordtb.Text.Length > 0
            && questioncb.Text.Length > 0
            && answertb.Text.Length > 0;
        if (canUpdate)
        {
            using (var con = new MySqlConnection(mySqlCon))
            using (var cmd = con.CreateCommand())
            {
                cmd = "INSERT INTO TeachersINFO('teachersid',firstname,lastname,gender,address,birthdate,position,empstatus,contactnumber,gradelevel,section,status) values (@teachersid,@firstname,@lastname,@gender,@address,@birthdate,@position,@empstatus,@contactnumber,@gradelevel,@section,@status);" + Environment.NewLine
                    + "INSERT INTO teacherslogin(teachersid,username,password,secretquestion,answer,status) values (@teachersid2,@username,@password,@secretquestion,@answer,@status2);" + Environment.NewLine
                    + "INSERT INTO teachersref(teachersid,FIU,oad,PrcNo,GSISBPNo,UMIDNo,TinNo,PhilHealthNo,CivilServiceE) values (@teachersid3,@FIU,@oad,@PrcNo,@GSISBPNo,@UMIDNo,@TinNo,@PhilHealthNo)";
                cmd.Parameters.AddWithValue("@teachersid", teacheridtb.Text);
                cmd.Parameters.AddWithValue("@firstname", firstnametb.Text);
                cmd.Parameters.AddWithValue("@lastname", lastnametb.Text);
                cmd.Parameters.AddWithValue("@gender", gendercb.Text);
                cmd.Parameters.AddWithValue("@address", addresstb.Text);
                cmd.Parameters.AddWithValue("@birthdate", birthdatetb.Text);
                cmd.Parameters.AddWithValue("@position", positioncb.Text);
                cmd.Parameters.AddWithValue("@empstatus", empstatuscb.Text);
                cmd.Parameters.AddWithValue("@contactnumber", contacttb.Text);
                cmd.Parameters.AddWithValue("@gradelevel", gradelevelcb.Text);
                cmd.Parameters.AddWithValue("@section", sectioncb.Text);
                cmd.Parameters.AddWithValue("@status", 1);
                //secondtable values p0ta kahit pandurugas to wala kong pake stored procedures parin tawag dito HAHAHA//
                cmd.Parameters.AddWithValue("@teachersid2", teacheridtb.Text);
                cmd.Parameters.AddWithValue("@username", usernametb.Text);
                cmd.Parameters.AddWithValue("@password", passwordtb.Text);
                cmd.Parameters.AddWithValue("@secretquestion", questioncb.Text);
                cmd.Parameters.AddWithValue("@answer", answertb.Text);
                cmd.Parameters.AddWithValue("@status2", 1);
                //thirdtable values hahaha pota pandaraya so much 
                con.Open();
                try
                {
                    var RowsAffected = cmd.ExecuteNonQuery();
                    succeeded = RowsAffected > 0;
                }
                catch (Exception ex)
                {
                    // Log the captured exception here
                    // E.g. if using NUnit do:
                    //      Log.Fatal(ex.ToString());
                }
            }
            if (succeeded)
            {
                MessageBox.Show("Registered Successfully", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                firstnametb.Text = "";
                lastnametb.Text = "";
                gendercb.SelectedItem = null;
                lastnametb.Text = "";
                addresstb.Text = "";
                gradelevelcb.SelectedItem = null;
                sectioncb.SelectedItem = null;
                answertb.Text = "";
                usernametb.Text = "";
                passwordtb.Text = "";
                questioncb.Text = "";
                empstatuscb.Text = "";
                positioncb.Text = "";
                fiutb.Text = "";
                oadtb.Text = "";
                prctb.Text = "";
                gsistb.Text = "";
                csetb.Text = "";
                //clearing textboxes fields.
            }
            else
            {
                MessageBox.Show("Some I/O error has occured.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        else
        {
            MessageBox.Show("Incomplete Data", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
