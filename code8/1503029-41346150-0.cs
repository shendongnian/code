    namespace screener2wl
    {
    	public class Program
    	{
    		static void Main(string[] args)
    		{
    			SortedSet<string> symbolsEstablished = new SortedSet<string>();
    			GetXmlDataSet("Expt 2buy.xml", ref symbolsEstablished);
    		}
    
    		public static void GetXmlDataSet(string fileName, ref SortedSet<string> symbols)
    		{
    			XmlSerializer xs = new XmlSerializer(typeof(DataSet));
    			StreamReader sr = new StreamReader(@"C:\Users\mehl\AppData\Roaming\Fidelity Investments\WealthLabPro\1.0.0.0\Data\DataSets\" + fileName);
    			DataSet s = (DataSet)xs.Deserialize(sr);
    			Console.WriteLine(s.DSString);
    			sr.Close();
    		}
    
    		[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    		[System.Xml.Serialization.XmlRootAttribute(IsNullable = false)]
    		public class DataSet
    		{
    			private string nameField;
    			private string scaleField;
    			private string barIntervalField;
    			private string dSStringField;
    			private string providerNameField;
    
    			[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    			public string Name
    			{
    				get { return this.nameField; }
    				set { this.nameField = value; }
    			}
    
    			[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    			public string Scale
    			{
    				get { return this.scaleField; }
    				set { this.scaleField = value; }
    			}
    
    			[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    			public string BarInterval
    			{
    				get { return this.barIntervalField; }
    				set { this.barIntervalField = value; }
    			}
    
    			[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    			public string DSString
    			{
    				get { return this.dSStringField; }
    				set { this.dSStringField = value; }
    			}
    
    			[System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    			public string ProviderName
    			{
    				get { return this.providerNameField; }
    				set { this.providerNameField = value; }
    			}
    		}
    	}
    }
