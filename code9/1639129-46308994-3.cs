    public class User : INode
    {
        public StringBuilder Path { get; } = new StringBuilder();
        public void MoveToFolder()
        {
            Path.AppendLine("Folder");
        }
        public void MoveToGroup()
        {
            Path.AppendLine("Group");
        }
        public override string ToString()
        {
            return Path.ToString();
        }
    }
