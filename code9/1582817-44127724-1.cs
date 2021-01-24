    public class MyControl :Control
    {
        public IMyPageInterface MyPage
        {
            get
            {
                return this.Page as IMyPageInterface;
            }
        }
    }
