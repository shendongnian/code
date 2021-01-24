    //Inherit from our external class
    public class NewClass: ExternalClass
    {
        //Note we do not have a copy of an ExternalClass object here.
        //This class itself will now have all of its instance members.
        public string NewProperty1 {get;set;}
        public string NewProperty2 {get;set;}
        //Base will call the constructor for the inherited class.
        //If it has parameters include those parameters in NewClass() and add them to base().
        //This is important so we don't have to write all the properties ourself.
        //In some cases it's even impossible to write to those properties making this approach mandatory.
        public NewClass(): base()
        {
        }
    }
