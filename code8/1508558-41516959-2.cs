    public partial class MyGeneric<T> : IMyGeneric<T> where T : IEntity
    {
        public MyGeneric(string stuff)
        {
            moreStuff(stuff);
        }
       //.. other stuff
    }
