    using Inheritance.Page;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Inheritance.Classes
    {
        public class PageController : Controller<PageModel, PageView>
        {
            public PageController():base()
            {
                
            }
    
            public PageModel Model
            {
                get
                {
                    return base._model;
                }
            }
        }
    }
