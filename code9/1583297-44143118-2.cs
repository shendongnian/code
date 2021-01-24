	void Main()
	{
		var edata = new Edata();
		edata.get_invoice_data();
		
		Console.WriteLine(edata._dup_check_lvl);
		Console.WriteLine(edata._inv_doc_type);
	}
	
	
	class Edata
	{
		public string _inv_doc_type { get; set; }
		public string _dup_check_lvl { get; set; }
	
		public void get_invoice_data()
		{
             // replace with reading from file.
			var doc = XDocument.Parse(@"<Invoice> 
		  <Check_Level> 2 </Check_Level>
		  <Document_Type> RE </Document_Type>
		</Invoice> ");
	
	
			var invoice_data = doc.Root;	// or doc.Element("Invoice")
	
			_inv_doc_type = invoice_data.Element("Check_Level").Value;
			_dup_check_lvl = invoice_data.Element("Document_Type").Value;
		}
	}
