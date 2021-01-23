    public static class StructEditor
    {
        public static void Edit<TStruct, TEditor>(ref TStruct s)
            where TEditor : IStructEditor<TStruct>, new()
        {
            new TEditor()
                .EditStuct(ref s);
        }
    }
    
    public interface IStructEditor<T>
    {
        void EditStuct(ref T s);
    }
    
    struct CostStruct
    {
        public int Cost;
    }
    
    class SetCost
        : IStructEditor<CostStruct>
    {
        public void EditStuct(ref CostStruct s)
        {
            s.Cost = 123;
        }
    }
