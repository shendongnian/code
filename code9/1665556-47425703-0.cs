    public class FacebookDataUser
    {
        public string FacebookDataUserId { get; set; } // You already have the primary key you need
        public string name { get; set; }
        public string birthday { get; set; }
        public string email { get; set; }
        public virtual Hometown hometown { get; set; }
        public virtual Location location { get; set; }
        public virtual Events events { get; set; }
        public virtual Likes likes { get; set; }
        public virtual Age_Range age_range { get; set; }
        public string gender { get; set; }
        public void InsertUser(FacebookDataUser Data, Likes MoreData)
        {
            using (SqlConnection myCon = new SqlConnection("connection_string"))
            {
                using (SqlCommand query = new SqlCommand("INSERT INTO users_table (@ID, ...) VALUES (ID, ...)", myCon))
                {
                    query.Parameters.AddWithValue("@ID", Data.FacebookDataUserId);
                    // add more parameters...
                    try
                    {
                        myCon.Open();
                        query.ExecuteNonQuery();
                    }
                    catch(Exception e)
                    {
                        throw e;
                    }
                    finally
                    {
                        myCon.Close();
                    }
                }
                using (SqlCommand query = new SqlCommand("INSERT INTO likes_table (..., @USERID) VALUES (..., USERID)", myCon))
                {
                    // add more parameters...
                    query.Parameters.AddWithValue("@USERID", Data.FacebookDataUserId); // you won't get any exception related to the foreign key because this user is already in the parent table
                    try
                    {
                        myCon.Open();
                        query.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    finally
                    {
                        myCon.Close();
                    }
                }
            }
        }
    }
