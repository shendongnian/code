    public void YourMethod(){
       string json = ...; // your json string 
       List<MyType> myType = JsonConvert.DeserializeObject<List<MyType>>(json);
       var output = string.Join(", ", myType);
    }
    public class MyType
    {
        public int Id
        {
            get;
            set;
        }
        public string Name{
            get;
            set;
        }
        public override string ToString()
        {
            return string.Format("{0}:{1}", Id.ToString(), Name);
        }
    }
