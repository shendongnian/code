    using System;
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Runtime.InteropServices;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Test test = new Test();
     
                Test.Book book1 = new Test.Book  { Keywords = new string[] { "a", "b", "c" }, Title = "123", Years = new int[] { 30 } };
                Test.IBook Ibook1 = (Test.IBook)book1;
                Test.Book book2 = (Test.Book)Ibook1;
                int[] temp = Ibook1.Years;
                Array.Resize(ref temp, 3);
                Ibook1.Years = temp;
            }
        }
        public class Test
        {
            
            [ComVisible(true)]
            [Guid("179181EF-8689-4CCA-B43E-34145F5A9608")]
            public interface IBook
            {
                string Title { [return: MarshalAs(UnmanagedType.BStr)] get; [param: MarshalAs(UnmanagedType.BStr)] set; }
                string[] Keywords { [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] get; [param: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] set; }
                int[] Years { [return: MarshalAs(UnmanagedType.SafeArray)] get; [param: MarshalAs(UnmanagedType.SafeArray)] set; }
            }
            [ComVisible(true)]
            [Guid("61AF9F28-3588-4C26-A971-2C42CFC2040B")]
            [ClassInterface(ClassInterfaceType.None)]
            public class Book : IBook
            {
                public string[] Keywords { get; set; }
                public string Title { get; set; }
                public int[] Years { get; set; }
            }
        }
     
    }
