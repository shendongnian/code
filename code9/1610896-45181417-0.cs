    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input = "{BEGIN:781}{hopi_docgen4}{sub_chronic_conditions_hpi}{END:781}{OPh_cc_docgen}{END:621}{BEGIN:768}{cc_reviewed} {cc_rev_prov}{END:768}";
                string output = RemovePattern(input, 781);
            }
            static string RemovePattern(string input, int id)
            {
                string output = "";
                string beginPattern = string.Format("{0}BEGIN:{1}{2}","{",id.ToString(), "}");
                string endPattern = string.Format("{0}END:{1}{2}","{",id.ToString(), "}");
                int lengthEnd = endPattern.Length;
                int beginIndex = input.IndexOf(beginPattern);
                int endIndex = input.IndexOf(endPattern);
                if((beginIndex >= 0) && (endIndex >= 0))
                {
                    int stringLength = (endIndex + lengthEnd) - beginIndex;
                    output = input.Substring(0, beginIndex) + input.Substring(endIndex + lengthEnd);
                }
                return output;
            }
        }
    }
