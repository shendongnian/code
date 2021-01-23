    interface IInterface<T>
    {
        T GetComments(int id);
    }
    public class A: IInterface<WallGetObject>
    {
        public WallGetObject GetComments()
        {
            WallGetObject item
            //... getting item
            return item
        }
    }
