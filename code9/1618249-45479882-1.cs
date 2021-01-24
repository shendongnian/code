    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Common;
    using System.Data.SqlClient;
    
    
    namespace YOUR NAMESPACE
    {
        public partial class FORMNAME: Form
        {
                 ClassResize Form;
    
           
    
            public FORMNAME()
            {
                
                InitializeComponent();
               Form = new ClassResize(this);
             
    
            }
            
        }
    }
