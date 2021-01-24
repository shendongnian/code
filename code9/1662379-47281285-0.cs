    interface IGClass<out T>
    {
        T Get();
    }
    class GClass<T> : IGClass<T>
    {
        T value;
        public GClass(T value)
        {
            this.value = value;
        }
        public T Get()
        {
            return value;
        }
    }
    //Simple interface
    interface IPos
    {
        int GetPos();
    }
    //Simple realization
    class PosClass : IPos
    {
        //Interface realization
        public int GetPos()
        {
            return 1;
        }
        public int GetAnotherImportantData()
        {
            return -1;
        }
    }
    class MainTrouble
    {
        public int DoUsingInterface(IGClass<IPos> interfaceableItem)
        {
            //Do work using only interface methods
            return interfaceableItem.Get().GetPos();
        }
        public int DoUsingInheritance()
        {
            GClass<PosClass> item = new GClass<PosClass>(new PosClass());
            var r = DoUsingInterface(item);
            
            return item.Get().GetAnotherImportantData();
        }
    }
