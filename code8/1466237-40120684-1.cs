    public class PersonImpl : BaseImplementation<PersonEntity, DataContext>
    {
        public void Method1()
        {
            var entity = CreateEntity();
            // entity is typeof(PersonEntity);
        }
    } 
