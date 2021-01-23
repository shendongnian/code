    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ExceptionExamples
    {
        public static class Error
        {
            [Serializable]
            public class RegistryReadException : Exception
            {
                /// <summary>
                /// Message template
                /// </summary>
                static string msg = "Can't parse value from Windows Registry.\nKey: {0}\nValue: {1}\nExpected type: {2}";
                /// <summary>
                /// Can't read value from registry
                /// </summary>
                /// <param name="message"></param>
                public RegistryReadException(
                    string message)
                    : base(message) { }
                /// <summary>
                /// Can't read value from registry
                /// </summary>
                /// <param name="key">Key path</param>
                /// <param name="value">Real value</param>
                /// <param name="type">Expected type</param>
                public RegistryReadException(
                    string key, string value, Type type)
                    : base( string.Format(msg, key, value, type.Name) ) { }
            }
        }
    }
