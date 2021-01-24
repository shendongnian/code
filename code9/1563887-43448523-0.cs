    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Web;
    namespace Rextester
    { public class Program {
     public static void Main(string[] args){
    string url = "localhost:8080/Site/List/hello%20test%20A89";
    string newUrl=System.Web.HttpUtility.UrlDecode(url);
     Console.WriteLine(newUrl);}}}
