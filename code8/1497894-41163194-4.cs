    using System;
    using System.Runtime.InteropServices;
    
    namespace IntellisenseDemo
    {
        [ComVisible(true)]
        [Guid("41B3F5BC-A52B-4AED-90A0-F48BC8A391F1")]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IIntellisenseDemo
        {
            int Number { get; set; }
            string TestString(string name);
        }
    
        [ComVisible(true)]
        [Guid("20EBC3AF-22C6-47CE-B70C-7EBBA12D0A29")]
        [ClassInterface(ClassInterfaceType.None)]
        [ProgId("IntellisenseDemo.Demo")]
        public class Demo : IIntellisenseDemo
        {
            public int Number { get; set; }
            public string TestString(string name)
            {
                throw new NotImplementedException();
            }
        }
    }
