    public virtual ObjectResult<tuser> GetActiveUsers()
    {
        try
        {
            Stringbuilder sb = new Stringbuilder();
            IObjectContextAdapter a = ((IObjectContextAdapter)this); // Breakpoint this line and F11 step through the code, looking at local variables as you go
            sb.AppendLine(", a: " + a.ToString());
            var b = a.ObjectContext;
            sb.AppendLine(", b: " + b.ToString());
            var c = b.ExecuteFunction<tuser>("GetActiveUsers");
            sb.AppendLine(", c: " + c.ToString());
            MessageBox.Show("No exception: (" + sb.ToString() + ")");
            return c;
        }
        catch(Exception ex)
        {
            MessageBox.Show("Exception: (" + ex.message + ex.stacktrace + ")");
        }
    }
