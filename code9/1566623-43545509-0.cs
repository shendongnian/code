    public class SomeService
    {
        public void DoSomething(some params or some instance of a model class)
        {
            Validate(some params or an instance of a model class);
            // some other codes such as save data in database or etc ...
        }
        private void Validate(some params or an instance of a model class)
        {
            if(something is wrong)
                throw new CustomException("X is invalid"); // X is the name of wrong param
        }
    }
