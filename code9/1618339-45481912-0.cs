    try{
        br.close();
        br.dispose();
    }
    catch(Exception exp)
    {
    //Assuming you have included using 'namespace System.Diagnostics'
    Debug.WriteLine(exp.ToString());
    }
