    public IHttpActionResult Post([FromBody]MyModel model)
    {
        if (ModelState.IsValid)
        {
            string myConnectionString = "...";
            string mySqlCommand = "UPDATE MyTable SET...";
    
            using (SqlConnection conn = new SqlConnection(myConnectionString))
            using (SqlCommand cmd = new SqlCommand(mySqlCommand, conn))
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
    
            return Ok();
        }
        else
            return BadRequest("Invalid data");
    }
