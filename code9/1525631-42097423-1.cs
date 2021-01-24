    public interface ICompany
    {
        string X { get; set; }
        string Y { get; set; }
    }
    public class Company : TreeNode, ICompany
    {
        public Company() { }
        public string X { get; set; }
        public string Y { get; set; }
    }
