    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication68
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input = "{\"rd\":\"1404900091\",\"d\":\"25994\",\"dddd\":99,\"pmcKey\":\"95abcdefgiJBMjU2R0NNS1ciLCJlbmMiOiJBMjU2Q0JDLUhTNTEyIiwiaXYiOiJBQVNNa0lsQ3l6blRsWktiIiwidGFnIjoiUlFuNUhVSWVHMVN0TmxJdXB5SGZNZyIsInppcCI6IkRFRiJ9.6zef568_zt8uZGlOdZZZga0FJV1CJcf-RdEIUk88ZtNyEmVX7eLnuce1nhkROgA03444LRiOxkFLFJ_eW5Um8w.k72DtsRbZzuTqWqOFlacVw.D3Sn9jiKRosZboqE0v999htZuyHu4Eukcq64Df5ga6XEOIOj6vDwR-2_NxzYs58kWpvP999SsXdYfqn1m9--h3lgcJEqOb2z4u_yXzxRWsGQe8kNwdWndFJox699999lQI0djiYAQtkhgqI6hgBS_muWiYar9WpP6K3fxPn99999cXlN6L0RdqWIl_U-wV5mlpMivxfyk0fMVcD1T9GTk99999aHpPPAYJ0pHIOYJjak2tj7J_nK4jPxrw7pNbQ3h2TB71JE5UTs4P9NgsL299999eb2wdJuOgJR9md-8PiGAJvWpgQSQu9HNvGowaTq.9999999991gjk0SQEXxfFBUTJKDANTdVBN52FURbIXQ\",\"id\":null,\"req\":null,\"page\":1,\"CDate\":null}";
                string pattern = "\"pmcKey\":\"[^\"]+\"";
                string output = Regex.Replace(input, pattern, "pmc\":\"abc\"");
                   
            }
        }
    }
