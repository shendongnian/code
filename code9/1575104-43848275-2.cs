    public interface IParentForm
    {
        string PubText {get; set;}
    }
    public class Parent_1 : Form, IParentForm
    {
        public string PubText
        {
             get { return this.pubText; }
             set { this.pubText = value; }
        }
    }
    //same for Parent_2 and 3
