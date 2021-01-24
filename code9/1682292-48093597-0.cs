    using System;
    using System.IO;
    using System.Text;
    
    class Test
    {
        public static void Main()
        {
            string strToProcess = "format_abc_endformat_def_endformat_ghi_end";
            char[] splitchar = { '@' };
           String[] Result =  strToProcess.Replace("_end", "@").Replace("format_", "@").Replace("@@", "@").Split(splitchar);
        }
    }
