    public class Full: Access.Job
    {
        public void mVoid()
        {
            Console.WriteLine(this.JobName);
        }
        protected void mProtVoid()
        {
            Console.WriteLine(this.JobName);
        }
        private void mPrivateVoid()
        {
            Console.WriteLine("Hey");
        }
    }
    Full myFull = new Full();
    myFull.mVoid();  //will work
    myFull.mProtVoid(); //Will not work
    myFull.mPrivateVoid(); //Will not work
