    MyUserControl view = new MyUserControl();
    string xaml;
    ControlTemplate ct = view.Template;
    using (var stream = new System.IO.MemoryStream())
    {
        System.Windows.Markup.XamlWriter.Save(ct, stream);
        xaml = Encoding.ASCII.GetString(stream.ToArray());
    }
    XNamespace ns = "http://schemas.microsoft.com/winfx/2006/xaml/presentation";
    XDocument oldTemplateXml = XDocument.Parse(xaml);
    XElement newTemplateXml = new XElement(ns + "ControlTemplate",
    new XElement(ns + "AdornerDecorator", oldTemplateXml.Root.DescendantNodes().First()));
    ControlTemplate newTemplate = System.Windows.Markup.XamlReader.Parse(newTemplateXml.ToString()) as ControlTemplate;
    view.Template = newTemplate;
