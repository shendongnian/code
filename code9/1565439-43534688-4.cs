    internal interface ICustomElement { IEnumerable<IElement> GetContent(); }
    internal class CustomElementFactory {
      public ICustomElement GetElement(XmlNode node) {
        switch (node.Name) {
          case "p": return new CustomParagraph (node, this);
          // implement the tags you need using the ICustomElement interface
          default: // e.g. treat unknown nodes as text
        }
    }
    public class PdfCreator {
      public byte[] GetPdf(XmlTemplate template) {
        PdfDocument doc ...
        CustomElementFactory factory ...
        foreach(XmlNode node in template.ChildNodes) {
          doc.AddElements(factory.GetElement(node).GetContent()); 
          // the point why all this is possible in such an easy generic way is that almost every itext element implements the IElement interface and therefore can be added to the document this way. And containers like PdfPCell are taking IElements as well.
          // Good job itext guys! ;)
        }
        return doc.CloseDocument();
      }
    }
    // here comes the magic:
    internal class CustomParagraph : ICustomElement {
      // ctor storing the xmlnode and factory in private field
      public IEnumerable<IElement> GetContent() {
        Paragraph p = new Paragraph();
        p.Add(node.InnerText); // create a underline or bold or whatever font here when you are implementing the special html tags
        
        // if the node has child elements, get their content by calling the factory.GetElement(child).GetContent() for each child. Then loop over the the IElement.Chunks collection of each IElement to add the containing chunks to the paragraph of this scope. This way you will be able to process nested html tags recursively.
        // find a way to pass the style information of this scope to the factory when processing child nodes, so you will be able to render <strong>bold<u>underlindANDBOLD</u></strong> stuff correctly
        return new List<IElement> { p };
      }
    }
