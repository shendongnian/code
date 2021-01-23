     try
       {
        Label1.Text = "Please wait...";
        RunMethod1();
        RunMethod2();
        RunMethod3();
        Label1.Text = "Success!";
       }
      catch(Exception ex)
       {
        Label1.Text = "Something wrong happened!";
       }
    }
    private void RunMethod1()
    {
        throw new NotImplementedException();
    }
    private void RunMethod2()
    {
        throw new NotImplementedException();
    }
    private void RunMethod3()
    {
        throw new NotImplementedException();
    }
