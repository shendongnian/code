    public class Parent
    {
        public Parent(string sP1FN, string sP1LN)
        {
            LChildID = new List<int>();
            sFirst_name1 = sP1FN;
            sLast_name1 = sP1LN;
        }
    
        public List<int> LChildID { get; set; }
