    using System;
    using System;
    using System.Net;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    
    namespace test_request
    {
        class MainClass
        {
            public static void Main (string[] args)
            {
    
                string unicode = "Not Your Boyfriend&#39;s Tunic";
                string str = System.Web.HttpUtility.HtmlDecode(unicode);
                Console.WriteLine (str);
            }
        }
    }
