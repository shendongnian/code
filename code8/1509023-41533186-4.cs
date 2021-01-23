    public Speler AddSpeler(string name, string club)
    {
        try
        {
           conn.Open();
           Speler speler = new Speler();
           .....
        
           ....
           return speler;
        }
        catch(Exception ex)
        {
            // display the ex.Message to know why your code fails
            MessageBox.Show(ex.Message);
            conn.Close();
            return null; // no Speler returned if code fails
        }
    }
