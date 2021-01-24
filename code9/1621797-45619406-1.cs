    public class Door
    {
        public void Open() { /* ... code ... */ }
        public void Close() { /* ... code ... */ }
    }
    public interface PasswordEncoded
    {
        void ChangeCode();
    }
    public class AdvancedDoor : Door, PasswordEncoded
    {
        public void ChangeCode() { /* ... code ... */ }
    }
    // ... elsewhere
    
    public void SomeFunction(Door someDoor)
    {
        if (someDoor is PasswordEncoded)
            ((PasswordEncoded)someDoor).ChangeCode();
    }
    
