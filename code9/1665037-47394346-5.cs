    public class ContactsUseCase {
        private readonly IMyModelContext ModelContext;
    
        public ContactsUseCase(IMyModelContext context) {
            ModelContext = context;
        }
    
        //...
    }
