    public class MagicClass
    {
        private int magicBaseValue;
        public MagicClass()
        {
            magicBaseValue = 9;
        }
        public Task<int> ItsMagic(int preMagic)
        {
            return Task.Factory.StartNew(() => preMagic * magicBaseValue);
        }
    }
    public class TestMethodInfo
    {
        public static void Main()
        {
            // Get the ItsMagic method and invoke with a parameter value of 100
            Type magicType = typeof(MagicClass);
            MethodInfo magicMethod = magicType.GetMethod("ItsMagic");
            var magicValue = ((Task<int>)(magicMethod.Invoke(Activator.CreateInstance(typeof(MagicClass)), new object[] { 100 }))).Result;
            Console.WriteLine("MethodInfo.Invoke() Example\n");
            Console.WriteLine("MagicClass.ItsMagic() returned: {0}", magicValue.ToString());
            Console.ReadKey();
        }
    }
