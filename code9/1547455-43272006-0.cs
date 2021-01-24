        try
        {
            Response.Clear();
            Response.Write(Converter.ToJson(resObj));
            Response.End();
        }
        catch (System.Threading.ThreadAbortException tae)
        {
            // ignore
        }
