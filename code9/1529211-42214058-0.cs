    public class Actor
    {
        //Fields 
        /*Write a class “Actor” that contains these attributes with the appropriate level of visibility explicitly defined: 
        “Name” which is a String, 
        “numberOfAwards” which is an integer
        “SAGMember” which is a bool*/
       
        private string name;
        private bool SAGMember;
        private int awardsNum;
        //property
        //4.Write a property (get/set) for the name attribute ONLY.
        private string Name
        {
            get { return name; }
            set { name = value; }
        }
        //constructor
        // Write a parameterless constructor for this class that initializes the name to “Bob Smith”, the number of awards to 0, and the SAGMember to “false”.  
        public Actor()
        {
            this.name = "bob smith";
            this.SAGMember = false;
            this.awardsNum = 0;
        }
        public Actor(string name, bool SAGMember, int awardsNum)
        {
            this.name = Name;
            this.SAGMember = true;
            this.awardsNum = 4;
        }
        // over ride 
        public override string ToString()
        {
            return string.Format("Actor: " + name + "\n" +  "\n" + "SAG Member: " + SAGMember + "Number of Awards: " + awardsNum );
        }
         
    }
