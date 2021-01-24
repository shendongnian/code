     public partial class Form1 : Form {
       ...
       //DONE: Extract method
       private static bool UserExists(string userName, string password) {
         //DONE: Do not cache connections, but recreate them
         using (MySqlConnection con = new MySqlConnection (@"...") {
            con.Open();
            //DONE: wrap IDisposable into using
            using (MySqlCommand cmd = con.CreateCommand()) {
              cmd.CommandType = CommandType.Text;
              //DONE: Make query being readable
              //DONE: Make query begin parametrized
              cmd.CommandText = 
                @"SELECT * 
                    FROM adminlogin 
                   WHERE username = @UserName 
                     AND password = @PassWord"; // <- A-A-A! Password as a plain text!
              //TODO: the simplest, but not the best solution: 
              // better to create parameters explicitly
              // cmd.Parameters.Add(...)
              cmd.Parameters.AddWithValue("@UserName", txtBoxUsername);   
              cmd.Parameters.AddWithValue("@PassWord", txtBoxPassword);   
              // If we have at least one record, the user exists
              using (var reader = cmd.ExecuteReader()) {
                return (reader.Read()); 
              }
            }
         }   
       }
