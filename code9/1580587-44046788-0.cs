    public static string FSQ(string s)
    {
           try
        {
            s = s.Trim();
            return s = (s != null && s != "")?(s.Contains("'") && !s.Contains("''"))?s.Replace("'", "''"): s:"";
                   
        }
        catch (Exception ex)
        {
            PEH("FDQ", "Common Module", ex.Message);
            return "";
        }
    } 
