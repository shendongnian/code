    using System;
    using System.Collections.Generic;
    namespace ANTLR_File_To_Arrray
    {
        public class ValuesListener : ValuesBaseListener
        {
            public List<double> doubles = new List<double>();
            public override void ExitNumber(ValuesParser.NumberContext context)
            {
                doubles.Add(Convert.ToDouble(context.GetChild(0).GetText()));
            }
        }
    }
