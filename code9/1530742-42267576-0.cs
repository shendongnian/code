    protected void gvTest_RowCommand (object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "progress")
        {
            int index = Convert.ToInt32(e.CommandArgument); //converts the row index stored in command argument property to an integer
            GridViewRow row = gvTest.Rows[index]; //retrieve the row that contains the button clicked by the user from the rows collection
            string state = (row.Cells[3].Text); //gets the value of the cell
            int id = Convert.ToInt32(gvTest.DataKeys[row.RowIndex].Value.ToString()); //gets the primary key value
            string sqlChangeStateToWaiting = "UPDATE task set IDState = @IdState where IDState = @IdStateInProgress";
            MySqlCommand cmdChangeStateToWaiting = new MySqlCommand(sqlUpdateState, conn);
            cmdChangeStateToWaiting.Parameters.AddWithValue("@IdState ", "id for in waiting");
            cmdChangeStateToWaiting.Parameters.AddWithValue("@IdStateInProgress", "id for in progress");
            string sqlUpdateState = "UPDATE task SET IdState=@IdState WHERE IdTask = @IdTask";
            MySqlCommand cmd = new MySqlCommand(sqlUpdateState, conn);
            cmd.Parameters.AddWithValue("@IdTask", id);
            cmd.Parameters.AddWithValue("@IdState", 1);
            conn.Open();
            cmdChangeStateToWaiting.ExecuteNonQuery();
            cmd.ExecuteNonQuery();
            conn.Close();
            LoadGridData();
        }
    }
