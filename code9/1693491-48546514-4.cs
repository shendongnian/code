    using System; 
    using System.Linq;
    using System.Text;
    
    public class Program
    { 
        public static string RunLengthEncode(string s)
        {
            if (string.IsNullOrEmpty(s)) // avoid null ref ex and do simple case
                return "";
    
            // we need a "state" between the differenc chars of s that we store here:
            char curr_c = s[0];  // our current char, we start with the 1st one
            int count = 0;       // our char counter, we start with 0 as it will be 
                                 // incremented as soon as it is processed by Aggregate 
                                 // ( and then incremented to 1)
            var agg = s.Aggregate(new StringBuilder(), (acc, c) =>
            {
                if (c == curr_c)
                    count++;  // same char, increment
                else
                {
                    // other char
                    if (count > 1) // store count if  > 1
                        acc.AppendFormat("{0}", count);
                    acc.Append(curr_c); // store char
    
                    curr_c = c; // set current char to new one
                    count = 1; // startcount now is 1
                }
                return acc;
            });
            // add last things
            if (count > 1) // store count if  > 1
                agg.AppendFormat("{0}", count);
            agg.Append(curr_c); // store char
    
            return agg.ToString();
        }
