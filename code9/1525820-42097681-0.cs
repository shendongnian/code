	XmlDocument xml = new XmlDocument();
	xml.Load(vnt.FileName);
    // namespace manager added here
	XmlNamespaceManager nsmgr = new XmlNamespaceManager(xml.NameTable);
	nsmgr.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3");
	XmlElement root = xml.DocumentElement;
	//gets sub total from cfdi:Comprobante
	XmlAttribute total = root.GetAttributeNode("subTotal");
	// HERE IS THE BIG PROBLEM
	XmlAttribute rfc = root.GetAttributeNode("cfdi:Comprobante/cfdi:Emisor/rfc");
	string valor = total.InnerXml;
	//string rfcE = rfc.InnerText; //HERE IS THE PROBLEM
	dataGridView1.Rows[0].Cells[2].Value = valor;
	// dataGridView1.Rows[0].Cells[1].Value = valor;
