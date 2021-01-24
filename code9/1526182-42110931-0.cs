    // Checks that the current node is an element and advances the reader to the next node.
    public virtual void ReadStartElement() {
    	if (MoveToContent() != XmlNodeType.Element) {
    		throw new XmlException(Res.Xml_InvalidNodeType, this.NodeType.ToString(), this as IXmlLineInfo);
    	}
    	Read();
    }
    
    // Checks whether the current node is a content (non-whitespace text, CDATA, Element, EndElement, EntityReference
    // or EndEntity) node. If the node is not a content node, then the method skips ahead to the next content node or 
    // end of file. Skips over nodes of type ProcessingInstruction, DocumentType, Comment, Whitespace and SignificantWhitespace.
    public virtual  XmlNodeType  MoveToContent() {
    	do {
    		switch (this.NodeType) {
    			case XmlNodeType.Attribute:
    				MoveToElement();
    				goto case XmlNodeType.Element;
    			case XmlNodeType.Element:
    			case XmlNodeType.EndElement:
    			case XmlNodeType.CDATA:
    			case XmlNodeType.Text:
    			case XmlNodeType.EntityReference:
    			case XmlNodeType.EndEntity:
    				return this.NodeType;
    		}
    	} while (Read());
    	return this.NodeType;
    }
