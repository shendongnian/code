    public partial class MyClass
    {
        [XmlUnknownElementEventHandler]
        void HandleOldElement(object sender, XmlElementEventArgs e)
        {
            if (e.Element.Name == "OldValue")
            {
                Debug## Heading ##.WriteLine("{0}: processed property {1} with value {2}", this, e.Element.Name, e.Element.OuterXml);
                MyValue = "Old value was: " + e.Element.InnerText;
            }
        }
    }
