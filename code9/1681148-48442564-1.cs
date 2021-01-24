    using System;
    using System.ComponentModel;
    using System.Configuration;
    using System.Windows.Forms;
    namespace YourAppNamespace
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                propertyGrid1.SelectedObject = Properties.Settings.Default;
                propertyGrid1.BrowsableAttributes = new AttributeCollection(new UserScopedSettingAttribute());
            }
            private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
            {
                Properties.Settings.Default.Save();
            }
        }
    }
