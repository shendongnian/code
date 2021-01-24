    using System;
    using System.Text.RegularExpressions;
    namespace StackOverflow_AutoPartialPropOverriding
    {
        class Program
        {
            static void Main(string[] args)
            {
                IStdModel model = new StdModel();
                Console.WriteLine($"StdName: {model.StdName}");
                Console.WriteLine($"StdNr: {model.StdNr}");
                /* StdName: steve
                 * StdNr: 1
                 */
                Console.ReadKey();
            }
        }
        public partial class StdModel
        {
            public string StdName { get; set; }
            public int StdNr { get; set; }
        }
        public interface IStdModel
        {
            string StdName { get; set; }
            int StdNr { get; set; }
        }
        public partial class StdModel : IStdModel
        {
            private string stdName = "steve";
            string IStdModel.StdName
            {
                get => stdName;
                set => value.ToUpper();
            }
            private int stdNr = 1;
            int IStdModel.StdNr
            {
                get => stdNr;
                set => stdNr = value; //value is already type int--not sure why you used regex
            }
        }
    }
