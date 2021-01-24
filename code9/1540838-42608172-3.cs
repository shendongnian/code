    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public class MyDataGridView : System.Windows.Forms.DataGridView
        {
            public override ISite Site
            {
                get
                {
                    return base.Site;
                }
                set
                {
                    base.Site = value;
    
                    if (Site != null)
                    {
                        IDesignerHost host = (IDesignerHost)Site.GetService(typeof(IDesignerHost));
                        if (host != null)
                        {
                            host.RemoveService(typeof(ITypeDiscoveryService));
                            host.AddService(typeof(ITypeDiscoveryService), new TypeDiscoveryService());
                        }
                    }
                }
            }
    
            static readonly Type[] columnTypes = new Type[] 
                    { 
                        typeof(MyDataGridViewButtonColumn), 
                        typeof(MyDataGridViewCheckBoxColumn), 
                        typeof(MyDataGridViewLinkColumn), 
                        typeof(MyDataGridViewImageColumn), 
                        typeof(MyDataGridViewComboBoxColumn), 
                        typeof(MyDataGridViewTextBoxColumn) 
                    };
    
            class TypeDiscoveryService : ITypeDiscoveryService
            {
                ICollection ITypeDiscoveryService.GetTypes(Type baseType, bool excludeGlobalTypes)
                {
                    return columnTypes;
                }
            }
    
        }
    
        [System.Windows.Forms.DataGridViewColumnDesignTimeVisible(true)]
        public class MyDataGridViewComboBoxColumn : System.Windows.Forms.DataGridViewComboBoxColumn
        {
        }
    
        [System.Windows.Forms.DataGridViewColumnDesignTimeVisible(true)]
        public class MyDataGridViewTextBoxColumn : System.Windows.Forms.DataGridViewTextBoxColumn
        {
        }
    
        [System.Windows.Forms.DataGridViewColumnDesignTimeVisible(true)]
        public class MyDataGridViewCheckBoxColumn : System.Windows.Forms.DataGridViewCheckBoxColumn
        {
        }
    
        [System.Windows.Forms.DataGridViewColumnDesignTimeVisible(true)]
        public class MyDataGridViewButtonColumn : System.Windows.Forms.DataGridViewButtonColumn
        {
        }
    
        [System.Windows.Forms.DataGridViewColumnDesignTimeVisible(true)]
        public class MyDataGridViewLinkColumn : System.Windows.Forms.DataGridViewLinkColumn
        {
        }
    
        [System.Windows.Forms.DataGridViewColumnDesignTimeVisible(true)]
        public class MyDataGridViewImageColumn : System.Windows.Forms.DataGridViewImageColumn
        {
        }
    
    
    
    
    }
