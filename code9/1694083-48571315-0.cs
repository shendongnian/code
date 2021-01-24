    [XmlRoot(ElementName="DeudasPorProducto")]
    public class DeudasPorProducto {
    	[XmlElement(ElementName="Producto")]
    	public List<Producto> Producto { get; set; }
    }
