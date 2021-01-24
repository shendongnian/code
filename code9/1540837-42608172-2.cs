    // System.Design.dll assembly must be included in the project.
    
    using System;
    using System.Collections;
    using System.Reflection;
    using System.Drawing.Design;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Globalization;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    
    namespace WindowsFormsApplication1
    {
        public class MyDataGridView : System.Windows.Forms.DataGridView
        {
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            [Editor(typeof(DataGridViewColumnCollectionEditor), typeof(UITypeEditor))]
            [MergableProperty(false)]
            public new System.Windows.Forms.DataGridViewColumnCollection Columns
            {
                get
                {
                    return base.Columns;
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
    
    
        internal class DataGridViewColumnCollectionEditor : UITypeEditor
        {
            //private DataGridViewColumnCollectionDialog dataGridViewColumnCollectionDialog;
            private Form dataGridViewColumnCollectionDialog;
    
            private DataGridViewColumnCollectionEditor()
            {
            }
    
            public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
            {
                if (provider != null)
                {
                    IWindowsFormsEditorService service = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                    if ((service == null) || (context.Instance == null))
                    {
                        return value;
                    }
                    IDesignerHost host = (IDesignerHost)provider.GetService(typeof(IDesignerHost));
    
                    if (host == null)
                    {
                        return value;
                    }
    
                    //if (this.dataGridViewColumnCollectionDialog == null)
                    //{
                    //    this.dataGridViewColumnCollectionDialog = new DataGridViewColumnCollectionDialog(((DataGridView)context.Instance).Site);
                    //}
    
                    if (this.dataGridViewColumnCollectionDialog == null)
                    {
                        Type type = Type.GetType("System.Windows.Forms.Design.DataGridViewColumnCollectionDialog");
    
                        this.dataGridViewColumnCollectionDialog = Activator.CreateInstance(
                            type,
                            BindingFlags.Instance | BindingFlags.NonPublic,
                            null,
                            new object[] { provider },
                            CultureInfo.CurrentCulture) as Form;
                    }
                    //this.dataGridViewColumnCollectionDialog.SetLiveDataGridView((DataGridView)context.Instance);
                    MethodInfo methodInfo = this.dataGridViewColumnCollectionDialog.GetType().GetMethod("SetLiveDataGridView", BindingFlags.NonPublic | BindingFlags.Instance);
                    methodInfo.Invoke(this.dataGridViewColumnCollectionDialog, new object[] { context.Instance });
    
                    //using (DesignerTransaction transaction = host.CreateTransaction(System.Design.SR.GetString("DataGridViewColumnCollectionTransaction")))
                    using (DesignerTransaction transaction = host.CreateTransaction())
                    {
                        host.RemoveService(typeof(ITypeDiscoveryService));
                        host.AddService(typeof(ITypeDiscoveryService), new TypeDiscoveryService());
                        ITypeDiscoveryService service2 = (ITypeDiscoveryService)host.GetService(typeof(ITypeDiscoveryService));
    
                        if (service.ShowDialog(this.dataGridViewColumnCollectionDialog) == DialogResult.OK)
                        {
                            transaction.Commit();
                            return value;
                        }
                        transaction.Cancel();
                    }
                }
                return value;
            }
    
            public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
            {
                return UITypeEditorEditStyle.Modal;
            }
    
            class TypeDiscoveryService : ITypeDiscoveryService
            {
                ICollection ITypeDiscoveryService.GetTypes(Type baseType, bool excludeGlobalTypes)
                {
                    return new Type[] { 
                        typeof(MyDataGridViewComboBoxColumn), 
                        typeof(MyDataGridViewTextBoxColumn),
                        typeof(MyDataGridViewCheckBoxColumn),
                        typeof(MyDataGridViewButtonColumn),
                        typeof(MyDataGridViewLinkColumn),
                        typeof(MyDataGridViewImageColumn)
                    };
                }
            }
    
        }
    
    
    
    }
