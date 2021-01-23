    class Program
    {
        public static void Main()
        {
            var model      = new Model();
            var view       = new MyView(model);
            var controller = new MyController(view, model);
        }
    }
