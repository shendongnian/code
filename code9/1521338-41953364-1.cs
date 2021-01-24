    public class Dog : Animal
    {
        protected override void Constructor()
        {
            MessageBox.Show("I'm a dog");
        }
    
        public Dog():base(false)
        {
            MessageBox.Show("I'm a dog's default constructor");
        }
    } 
