    public interface IMultimeter
    {
        //TODO: declare members
    }
    public static class MulimeterFactory
    {
        private class Racal_4152A : IMultimeter
        {
            //TODO: Implement interface
        }
        private class Agilent_XXX : IMultimeter
        {
            //TODO: Implement interface
        }
        public static IMultimeter Create_Racal_4152A()
        {
            return new Racal_4152A();
        }
        public static IMultimeter Create_Agilent_XXX()
        {
            return new Agilent_XXX();
        }
    }
