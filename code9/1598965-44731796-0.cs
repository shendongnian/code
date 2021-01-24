    using System;
    using System.CodeDom.Compiler;
    using Microsoft.CSharp;
    using System.Reflection;
    internal class CS
        {
        private static MethodInfo methIsKeyword;
        static CS()
            {
            using (CSharpCodeProvider cs = new CSharpCodeProvider())
                {
                FieldInfo infoGenerator = cs.GetType().GetField("generator", BindingFlags.Instance | BindingFlags.NonPublic);
    
                object gen = infoGenerator.GetValue(cs);
                methIsKeyword = gen.GetType().GetMethod("IsKeyword", BindingFlags.Static | BindingFlags.NonPublic);
                }
            }
        public static bool IsKeyword(string input)
            {
            return Convert.ToBoolean(methIsKeyword.Invoke(null, new object[] { input.Trim() }));
            }
        }
