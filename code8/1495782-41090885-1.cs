    public interface IMyClassClient<T>
    {
        MyClass<T> Default();
    }
    public class MyClass<T>
    {
        private IMyClassClient<T> owner;
        private MyClass<T> test;
        public MyClass<T> Test
        {
            get { return test; }
            set
            {
                if (value == owner.Default())
                {
                    MessageBox.Show("Well that's true");
                }
            }
        }
    }
