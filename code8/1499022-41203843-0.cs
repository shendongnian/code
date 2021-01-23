    private bool CheckUsername(string username)
    {
        try
        {
            return list.Any(x => x.username == username);
        }
        catch (ArgumentNullException ex)
        {
            MessageBox.Show(ex.Message);
            return false;
        }
    }
