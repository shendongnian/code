    [System.Web.Script.Services.ScriptService]
    public class Registration : WebService
    {
        [WebMethod]
        public string InsertRegistration(string firstname, string lastname,
                    string email, string password, string address)
        {
            try
            {
                using (var con = new NpgsqlConnection(
             "Server=127.0.0.1;Port=5432;Database=TEST_DB;User Id=user;Password=password;"))
                using (var cmd = new NpgsqlCommand(
           "insert into public.registration1(firstname, lastname, email, passwordhash, address)"
                 + " values (@firstName, @lastName, @email, @passwordhash, @address);", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@firstName", firstname);
                    cmd.Parameters.AddWithValue("@lastName", lastname);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@passwordhash", HashMyPassword(password));
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.ExecuteNonQuery();
                }
                return "Record Inserted Successfully";
            }
            catch (Exception)
            {
                return "Failed";
            }
        }
        public static string HashMyPassword(string unhashed)
        {
           // use a decent hashing algo like PBKDF2 or scrypt
        }
    }
