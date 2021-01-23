    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Tester {
        static class Program {
            static void Test(string name, object element) {
                Console.Write($"{name}: ");
                Console.WriteLine(element is object[] && !((object[])element).Any());
            }
            static void Main(string[] args) {
                Test("new object()",       new object());       // false
                Test("new { }",            new { });            // false
                Test("new object[0]",      new object[0]);      // true
                Test("new object[1]",      new object[1]);      // false
                Test("new List<object>()", new List<object>()); // false
                // Note: object[] o = new List<object>(); wouldn't be allowed.
                Test("new string[0]",      new string[0]);      // true
                // Note: object[] o = new string[0]; would be allowed.
                Test("new int[0]",         new int[0]);         // false
                // Note: object[] o = new int[0]; wouldn't be allowed.
            }
        }
    }
