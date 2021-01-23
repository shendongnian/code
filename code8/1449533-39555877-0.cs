    if (i == len - 1)
    {
        update += "[" + calc + "] = " + this.GetType().GetProperty(sys).GetValue(this, null)+ ";";
    }
    else
    {
        update += "[" + calc + "] = " + this.GetType().GetProperty(sys).GetValue(this, null)+ ", ";
    }
