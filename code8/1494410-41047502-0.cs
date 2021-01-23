        public interface IPersonFormatter
        {
                string asFullName();                 // Returns "firstName lastName";
                string asCSVRecord();                  // Returns "id,firstName,lastName" to be imported to Excel
        }
        public class ConcretePersonFormatter : IPersonFormatter
        {
                //Members
                private Person _personInstance;
                
                public ConcretePersonFormatter(Person p)
                {
                        _personInstance = p;
                }
                
                //IPersonFormatter implementation
                string asFullName()
                {
                        return _personInstance.firstName + " " + _personInstance.lastName;
                }
                
                string asCSVRecord()
                {
                        return _personInstance.id + "," + _personInstance.firstName + "," + _personInstance.lastName;
                }
        }
