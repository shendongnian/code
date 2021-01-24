    try
    {
        myCnx3.Open();
        writeCommentSQL.ExecuteNonQuery(); //What if this throws exception?
        myCnx3.Close();
    
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.ToString());
        Dts.TaskResult = (int)ScriptResults.Failure;
    }
