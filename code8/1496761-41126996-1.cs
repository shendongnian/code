    public class Person
    {
        // Sorry but I have no idea of what Siffra means... 
        // change the name as you wish
        public string Siffra {get;set;}
        ...... other properties
        public string kollaKön()
        {
            // A defensive attitude is always a good practice.
            if(string.IsNullOrEmpty(this.Siffra) ||
               this.Siffra.Length < 10)
               return "Invalid Siffra";
            string siffraAsString = this.Siffra.Substring(8, 1);
            int siffraAsNum = int.Parse(siffraAsString);
            int result = (siffraAsNum % 2);
            return (result == 1 ? "Är en Man" : " Är en Kvinna");
        }
    }
