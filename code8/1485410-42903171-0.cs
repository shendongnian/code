    +using System.Reflection ;
    +using Microsoft.VisualStudio.TestTools.UnitTesting ;
     namespace YourAppNamespace
     {
         /// <summary>
         /// Interaction logic for App.xaml.
         /// </summary>
    +    [TestClass]
         public partial class App
         {
    +        [TestMethod]
    +        public void Test ()
    +        {
    +            ResourceAssembly = Assembly.GetExecutingAssembly () ;
    +            InitializeComponent () ;
    +            Run () ;
    +        }
         }
     }
