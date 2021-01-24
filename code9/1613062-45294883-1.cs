       public class Selectable(View)Model
        {
    
        [XmlAttribute]
        public string Code { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Description { get; set; }
    }
    ///you can deserialize your view model directly
    private ObservableCollection<SelectableViewModel> CreateData()
    {
       return new ObservableCollection<SelectableViewModel>( Deserialize( file_name_code_lang.xml, SelectableViewModel) );
    }
    //    or going through a model class
    private ObservableCollection<SelectableViewModel> CreateData()
        {
           return new ObservableCollection<SelectableViewModel>( Deserialize( file_name_code_lang.xml, SelectableModel ).Foreach(p=> new SelectableViewModel(p) );
        }
    static public object Deserialize(string filePath, Type objType)
		{
			object objToDeserialize = null;
			XmlTextReader xmlReader = null;
			XmlSerializer xmls = null;
			try
			{
				xmlReader = new XmlTextReader(filePath);
				xmls = new XmlSerializer(objType);
				objToDeserialize = xmls.Deserialize(xmlReader);
			}
			catch (Exception err)
			{
				BusinessLogger.Manage(err);
				return null;
			}
			finally
			{
				xmls = null;
				xmlReader.Close();
			}
			return objToDeserialize;
		}
