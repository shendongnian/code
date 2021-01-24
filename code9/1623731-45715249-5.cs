     mHandler = new MyHandler(this);
     ...
    public class MyHandler : Handler
        {
            public MainActivity mainActivity;
            public MyHandler(MainActivity mainActivity)
            {
                this.mainActivity = mainActivity;
            }
            public override void HandleMessage(Message msg)
            {
                try
                {
                    throw new RuntimeException();
                }
                catch
                {
                }
                finally
                {
                    if (msg.What == 0)//click yes
                    {
                        var a = mainActivity.ConfirmOperation("AABBCCDD");//return true;
                        Toast.MakeText(mainActivity, "user_Click_yes", ToastLength.Short).Show();
                    }
                    else if (msg.What == 1)//click no
                    {
                        var a = mainActivity.ConfirmOperation("user_Click_no");//return false;
                        Toast.MakeText(mainActivity, "user_Click_no", ToastLength.Short).Show();
                    }
                }
            }
        }
