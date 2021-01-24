    public class MyHandler : Handler
    {
        private MainActivity mainActivity;
        public MyHandler(MainActivity mainActivity)
        {
            this.mainActivity = mainActivity;
        }
        public override void HandleMessage(Message msg)
        {
            switch (msg.Arg1)
            {
                case 0:
                    //true
                    mainActivity.Exist();
                    mainActivity.mDialog.Dismiss();
                    break;
                case 1:
                    //false
                    mainActivity.Regist();
                    mainActivity.mDialog.Dismiss();
                    break;
                default:
                    break;
            }
            base.HandleMessage(msg);
        }
    }
