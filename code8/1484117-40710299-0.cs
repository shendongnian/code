    public abstract class Cell<T>
    {
        int address;
        T value;
        protected Cell(int address, T value)
        {
        }
    }
    public class CellInt : Cell<int>
    {
        public CellInt(int address, int value): base(address, value) { }
    }
