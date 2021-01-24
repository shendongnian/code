    Comment :  // Problem in your query. Please write Actual DB Field Name of 
    your SQL in below line.
    public ActionResult Create(UserModel usr)
    {
        con.Open();
	    Comment :  // Problem in your query. Please write Actual DB Field Name 
                      of your SQL in below line.
     string query = "Insert into Tbl_User 
    (Field1,Field2,Field3,Field4,Field5,Field6,Field7) 
    Values(@Usr_Name,@FirstName,@LastName,@Gender,@Phone,@Address,@Email)";
         SqlCommand cmd = new SqlCommand(query, con);
         SqlParameter usrname = cmd.Parameters.AddWithValue("@Usr_Name", 
         usr.Usr_Name);
    if (usr.Usr_Name == null)
    {
        usrname.Value = DBNull.Value;
    }
    SqlParameter fname = cmd.Parameters.AddWithValue("@FirstName", usr.First_Name);
    if (usr.First_Name == null)
    {
        fname.Value = DBNull.Value;
    }
    cmd.Parameters.AddWithValue("@LastName", usr.Last_Name);
    cmd.Parameters.AddWithValue("@Gender", usr.Gender);
    cmd.Parameters.AddWithValue("@Phone", usr.Phone);
    cmd.Parameters.AddWithValue("@Address", usr.Address);
    cmd.Parameters.AddWithValue("@Email", usr.Email);
    cmd.ExecuteNonQuery();
    return RedirectToAction("Index");
     }
