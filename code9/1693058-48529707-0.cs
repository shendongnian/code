    try
    {
        teacher.Save();
        MessageBox.Show("Teacher saved","Success");
    }
    catch(Exception saveError)
    {
        MessageBox.Show("Problem saving file", "Error" + saveError.Message);
    }
