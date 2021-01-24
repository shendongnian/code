    using System.Windows.Markup;
    using System.Xml;
    using System.IO;
    
    T CloneXaml(T source){
        string xaml = XamlWriter.Save(T);
        using (StringReader stringReader = new StringReader(xaml))
        using (xmlReader = XmlReader.Create(stringReader))
            return (T)XamlReader.Load(xmlReader);
    }
    lloMatrixCopy = lloMatrix.Select( inner => inner.ToList().Select(CloneXaml)).ToList();
