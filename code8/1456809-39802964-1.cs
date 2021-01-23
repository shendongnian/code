    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    /*  Class1 is in project Ass1 , import project Ass1 */
    using Ass1;
    namespace Ass2
    {
        public class Class2
        {
            public void foo()
            {
               Class1 cd = new Class1();  /* gives error: is afield but is used like a type*/
               cd.print();
            }
            
        }
    }
