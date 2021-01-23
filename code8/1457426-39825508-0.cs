    public class ParentClass : Form
    {
        public ParentClass() {
            this.FormClosed += sendString;
        }
        private void sendString(object sender, FormClosedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
    public class GenericEvent : ParentClass { }
    public class LibClass1 : ParentClass { }
    public class LibClass2 : ParentClass { }
    public class Client : ParentClass { }
