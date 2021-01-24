    protected void resetpass_Click(object sender, EventArgs e) {
       // Here is data reader
       SqlDataReader reader = null;
       // ...
       reader = cmd.ExecuteReader();
       if( reader != null && reader.HasRows ) {
          // ...
          // and here is another one within the above data reader
          SqlDataAdapter updates = new SqlDataAdapter( "update reg set Password='" + newpass.Text + "'", con );
       }
    }
