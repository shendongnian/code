    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;
    [ProvideProperty("SomeProperty", typeof(Control))]
    public class ControlExtender : Component, IExtenderProvider
    {
        private Hashtable somePropertyValues = new Hashtable();
        public bool CanExtend(object extendee)
        {
            return (extendee is TextBox ||
                    extendee is Button);
        }
        public string GetSomeProperty(Control control)
        {
            if (somePropertyValues.ContainsKey(control))
                return (string)somePropertyValues[control];
            return null;
        }
        public void SetSomeProperty(Control control, string value)
        {
            if (string.IsNullOrEmpty(value))
                somePropertyValues.Remove(control);
            else
                somePropertyValues[control] = value;
        }
    }
