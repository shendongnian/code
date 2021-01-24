    private string ReadDescription(out bool success)
    {
            success = false;
            if (txtDescription.Text == "")
            {
                GiveMessage("Ivalid description");
                success = false;
            }
            else
                success = true;  
            return success;
    }
