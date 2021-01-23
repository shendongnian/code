    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            test();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.InnerException.ToString());
        }
    }
    public void test()
    {
        try
        {
            int a = 1;
            int b = 0;
            int x = 0;
            x = a / b;
        }
        catch (Exception e)
        {
            throw new Exception("inner exception", e);
        }
    }
