    public String DeleteDeleteCountry([FromBody]string cntryId)
    {
        if (cntryId != null)
        {
            return repoCountry.DeleteCountry(Convert.ToInt32(cntryId));
        }
        else
        {
            return "0";
        }
    }
