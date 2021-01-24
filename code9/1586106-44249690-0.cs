     //DONE: extract business logics, do not mix it with UI
     private bool DropContact(string id) {
       //DONE: do not share single connection, but create when you want it
       //DONE: wrap IDisposable into using
       using (SqlConnection con = new SqlConnection(ConnectionStringHere)) {
         con.Open();
         //DONE: make sql readable
         //DONE: make sql parametrized
         string cadena = 
           @"DELETE 
               FROM contacts 
              WHERE id = @prm_id";
         //DONE: wrap IDisposable into using
         using (SqlCommand command = new SqlCommand(cadena, con)) {
           //TODO: explict parameter type (int/string?) is a better then inplicit AddWithValue
           command.Parameters.AddWithValue("@prm_id", id);
           return command.ExecuteNonQuery() >= 1;
         }
       } 
     }
     ...
     private void button2_Click(object sender, EventArgs e) {
       if (DropContact(textBox1.Text)) {
         label4.Text = "";
         label5.Text = "";
         MessageBox.Show("Se ha eliminado");
       }
       else {
         MessageBox.Show("No existe un artículo con el código ingresado");
       }
       button2.Enabled = false;
     } 
