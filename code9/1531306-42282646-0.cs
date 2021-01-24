    public class Test{
    public bool testBool { get; set; }
     public void Method()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    if (testBool)
                    {
                        testBool = false;
                    }
                }));
            }
            else
            {
                if (testBool)
                {
                    testBool = false;
                }
            }
        }
    }
