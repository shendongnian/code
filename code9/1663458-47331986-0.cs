    public interface IMagic {
        ITable CreateTable(string name);
    }
    
    public interface ITable {
        void AddColumn(Type type, string name);
    }
