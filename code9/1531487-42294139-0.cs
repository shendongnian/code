    protected void someFunction()
    {
        DataTable dt = getDataFromDataBase();
        CheckBox cb = null;
        for(int r=0;r<dt.Rows.Count;r++)
        {
            cb = new CheckBox();
            cb.Checked = mDbValueToBool((String)dt.Rows[r]["Add Additional Part"]));
            mForm.Controls.Add(cb);
        }
    }
    protected Boolean mDbValueToBool(String boolValue)
    {
        if(boolValue.Equals("YES"))
            return true;
        return false;
    }
