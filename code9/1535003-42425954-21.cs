    [XmlRoot("MotProjects")]
    public class XMLStructure
    {
        // Fixed - made public and marked with [XmlElement]
        [XmlElement("Project")]
        public List<Project> LProject;
        public XMLStructure()
        {
            LProject = new List<Project>();
        }
        // Fixed - removed duplicates.
        // InnerException: System.InvalidOperationException
        // Message="Types 'Question42409171.XMLStructure.Project.Package.NameElement' and 'Question42409171.XMLStructure.Project.NameElement' both use the XML type name, 'NameElement', from namespace ''. Use XML attributes to specify a unique XML name and/or namespace for the type."
        public class NameElement 
        {
            // Fixed
            // This was marked as an element but should be an attribute
            [XmlAttribute("name")]
            public string name;
            public NameElement()
            {
                name = "";
            }
        }
        public class Project
        {
            [XmlAttribute("name")]
            public string name;
            [XmlAttribute("exec")]
            public string exec;
            // Fixed missing property
            [XmlElement("Defines")]
            public NameElement Defines;
            // Fixed missing property
            [XmlElement("Make")]
            public NameElement Make;
            // Fixed missing property
            [XmlElement("Include")]
            public NameElement Include;
            [XmlElement("Ref_mot")]
            public NameElement Ref_mot;
            [XmlElement("Folder")]
            public NameElement Folder;
            [XmlElement("MotCommand")]
            public NameElement MotCommand;
            [XmlElement("Param4MotCommand")]
            public NameElement Param4MotCommand;
            [XmlElement("ExtraDefine")]
            public NameElement ExtraDefine;
            [XmlElement("Package")]
            public Package MYPackage;
            [XmlElement("MotImage")]
            public MotImage Mot_Image;
            [XmlElement("MigrationAndDevicesBin")]
            public MigrationAndDevicesBin _MigrationAndDevicesBin;
            [XmlElement("SerialFlashHexImage")]
            public SerialFlashHexImage MYSerialFlashHexImage;
            [XmlElement("Flasher")]
            public Flasher MFlasher;
            public Project()
            {
                name = "";
                exec = "";
                Include = new NameElement();
                Ref_mot = new NameElement();
                Folder = new NameElement();
                MotCommand = new NameElement();
                Param4MotCommand = new NameElement();
                ExtraDefine = new NameElement();
                Mot_Image = new MotImage();
                MYPackage = new Package();
                _MigrationAndDevicesBin = new MigrationAndDevicesBin();
                MYSerialFlashHexImage = new SerialFlashHexImage();
                MFlasher = new Flasher();
            }
            public class MotImage
            {
                [XmlAttribute("name")]
                public string name;
                [XmlAttribute("exec")]
                public string exec;
                [XmlElement("Boot_path")]
                public NameElement Boot_path;
                [XmlElement("Rsu_path")]
                public NameElement Rsu_path;
                [XmlElement("Release_path")]
                public NameElement Release_path;
                [XmlElement("Image_path")]
                public NameElement Image_path;
                [XmlElement("Catalog_number")]
                public NameElement Catalog_number;
                [XmlElement("Additional_text")]
                public NameElement Additional_text;
                public MotImage()
                {
                    name = "";
                    exec = "";
                    Boot_path = new NameElement();
                    Rsu_path = new NameElement();
                    Release_path = new NameElement();
                    Image_path = new NameElement();
                    Catalog_number = new NameElement();
                    Additional_text = new NameElement();
                }
            }
            public class Package
            {
                [XmlAttribute("name")]
                public string name;
                [XmlAttribute("exec")]
                public string exec;
                // Fixed
                // InnerException: System.InvalidOperationException
                // Message="Cannot serialize member 'Release_path' of type Question42409171.XMLStructure.Project.Package.NameElement. XmlAttribute/XmlText cannot be used to encode complex types."
                [XmlElement("Release_path")]
                public NameElement Release_path;
                // Fixed
                // InnerException: System.InvalidOperationException
                // Message="Cannot serialize member 'Rsu_path' of type Question42409171.XMLStructure.NameElement. XmlAttribute/XmlText cannot be used to encode complex types."
                [XmlElement("Rsu_path")] // Fixed 
                public NameElement Rsu_path;
                [XmlElement("Migration_path")]
                public NameElement Migration_path;
                [XmlElement("Default_path")]
                public NameElement Default_path;
                [XmlElement("Old_Release_path")]
                public NameElement Old_Release_path;
                [XmlElement("Old_Default_path")]
                public NameElement Old_Default_path;
                [XmlElement("Package_path")]
                public NameElement Package_path;
                [XmlElement("Additional_text")]
                public NameElement Additional_text;
                [XmlElement("Catalog_number")]
                public NameElement Catalog_number;
                public Package()
                {
                    name = "";
                    exec = "";
                    Release_path = new NameElement();
                    Rsu_path = new NameElement();
                    Migration_path = new NameElement();
                    Default_path = new NameElement();
                    Old_Default_path = new NameElement();
                    Old_Release_path = new NameElement();
                    Rsu_path = new NameElement();
                    Release_path = new NameElement();
                    Catalog_number = new NameElement();
                    Additional_text = new NameElement();
                }
            }
            public class MigrationAndDevicesBin
            {
                [XmlAttribute("name")]
                public string name;
                [XmlAttribute("exec")]
                public string exec;
                // Fixed - should be [XmlElement]
                [XmlElement("Device")]
                public List<Device> _Device;
                [XmlElement("Catalog_number")]
                public NameElement Catalog_number;
                [XmlElement("OutputFile")]
                public OutputFile OutPutFile;
                public MigrationAndDevicesBin()
                {
                    name = "";
                    exec = "";
                    _Device = new List<Device>();
                    Catalog_number = new NameElement();
                    OutPutFile = new OutputFile();
                }
            }
            public class Device
            {
                [XmlAttribute("id")]
                public string id;
                [XmlAttribute("productType")]
                public string productType;
                [XmlAttribute("swVersion")]
                public string swVersion;
                [XmlAttribute("pathname")]
                public string pathname;
                public Device()
                {
                    id = "";
                    productType = "";
                    swVersion = "";
                    pathname = "";
                }
            }
            public class OutputFile
            {
                [XmlElement("pathname")]
                public string pathname;
                public OutputFile()
                {
                    pathname = "";
                }
            }
            public class SerialFlashHexImage
            {
                [XmlAttribute("name")]
                public string name;
                [XmlAttribute("exec")]
                public string exec;
                // Fixed - the type File was not even used!
                [XmlElement("File")]
                public List<File> Files { get; set; }
                public SerialFlashHexImage()
                {
                    this.Files = new List<File>();
                    name = "";
                    exec = "";
                }
                public class File
                {
                    [XmlAttribute("name")]
                    public string name;
                    [XmlAttribute("exec")]
                    public string exec;
                    [XmlAttribute("id")]
                    public string id;
                    [XmlAttribute("fileType")]
                    public string fileType;
                    [XmlAttribute("pathname")]
                    public string pathname;
                    [XmlElement("OutputFile")]
                    public OutputFile OutputFile;
                    [XmlElement("Catalog_number")]
                    public NameElement Catalog_number;
                    public File()
                    {
                        name = "";
                        exec = "";
                        id = "";
                        fileType = "";
                        pathname = "";
                        OutputFile = new OutputFile();
                        Catalog_number = new NameElement();
                    }
                }
            }
            public class Flasher
            {
                // Fixed - missing attribute
                [XmlAttribute("name")]
                public string name;
                // Fixed - missing attribute
                [XmlAttribute("exec")]
                public string exec;
                //Fixed
                //InnerException: System.InvalidOperationException
                //Message="For non-array types, you may use the following attributes: XmlAttribute, XmlText, XmlElement, or XmlAnyElement."
                [XmlElement("Item")]
                public List<Item> items;
                public Flasher()
                {
                    items = new List<Item>();
                    name = "";
                    exec = "";
                }
                public class Item
                {
                    [XmlAttribute("name")]
                    public string name;
                    [XmlAttribute("value")]
                    public string value;
                    public Item()
                    {
                        name = "";
                        value = "";
                    }
                }
            }
        }
    }
