    public class Student
    {
        public int id { get; }
        public string name { get; set; }
        public string address { get; set; }
        
        public void Update(Student st)
        {
            this.name = st.name;
            this.address = st.address;
        }
    }
