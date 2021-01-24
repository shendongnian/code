    [DelimitedRecord(",")]
    [IgnoreEmptyLines]
    public class MySpec
    {
        public string Column1;
        public string Column2;
        public string Column3;
        public string Column4;
        public string Column5;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var fileHelpersEngine = new FileHelperEngine<MySpec>();
            var records = fileHelpersEngine.ReadString("Clip Ons,,D02,8 Card Wallet,Y");
            var firstRecord = records.First();
            Assert.AreEqual("Clip Ons", firstRecord.Column1);
            Assert.AreEqual(string.Empty, firstRecord.Column2);
            Assert.AreEqual("D02", firstRecord.Column3);
            Assert.AreEqual("8 Card Wallet", firstRecord.Column4);
            Assert.AreEqual("Y", firstRecord.Column5);
            Console.ReadKey();
        }
    }
