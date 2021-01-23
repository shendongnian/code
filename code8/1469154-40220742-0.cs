      [XmlRoot( Namespace = "http://biz.si/Project/v0100/Data.xsd", IsNullable = false )]
      [XmlType( AnonymousType = true )]
      public class sventevitData
      {
        [XmlAttribute]
        public string Id { get; set; }
    
        [XmlAttribute]
        public string Status { get; set; }
    
        [XmlElement( "DataGroup" )]
        public DataGroup DataGroup { get; set; }
    
    
        /// <summary>
        /// Initializes a new instance of the <see cref="sventevitData"/> class.
        /// Parameterless constructor required for .NET XML serialization
        /// </summary>
        public sventevitData(){}
    
        public void SerializeData( String FileWithPath )
        {
          try
          {
            using( Stream stream = new FileStream(  FileWithPath,     FileMode.Create, 
                                                    FileAccess.Write, FileShare.Write ) )
            {
              //  Serialize into the storage medium
              XmlSerializer xmlserial = new XmlSerializer( typeof( sventevitData ) );
              xmlserial.Serialize( stream, this );
              stream.Close();
            }
          }
          catch( Exception ex )
          {
            string msg  = ex.Message;
            ex = ex.InnerException;
    
            while( ex != null )
            {
              msg += "" + ex.Message;
              ex = ex.InnerException;
            }
    
            System.Windows.Forms.MessageBox.Show( 
              String.Format( "Exception writing sventevitData {0}: {1}", 
                              FileWithPath, msg ) );
          }
        }
    
    
        public static sventevitData DeserializeData( String FileWithPath )
        {
          sventevitData tmp;
          Stream stream;
    
          try
          {
            // Read the file back into a stream
            if( !File.Exists( FileWithPath ) )
            {
              DirectoryInfo di = null;
    
              if( !Directory.Exists( Path.GetDirectoryName( FileWithPath ) ) )
              {
    
                AddDirSecurity( Path.GetDirectoryName( FileWithPath ),
                                System.Security.Principal.WindowsIdentity.GetCurrent().Name,
                                FileSystemRights.Write, AccessControlType.Allow );
    
                di = Directory.CreateDirectory( Path.GetDirectoryName( FileWithPath ) );
              }
    
              AddDirSecurity( FileWithPath, System.Security.Principal.WindowsIdentity.GetCurrent().Name,
                                  FileSystemRights.Write, AccessControlType.Allow );
    
              File.Create( FileWithPath );
            }
    
            using( stream = new FileStream( FileWithPath, FileMode.Open, FileAccess.Read, FileShare.Read ) )
            {
              // Now create a binary formatter
              XmlSerializer xmlserializer = new XmlSerializer( typeof( sventevitData ) );
              stream = new FileStream( FileWithPath, FileMode.Open, FileAccess.Read, FileShare.Read );
              tmp = ( sventevitData )xmlserializer.Deserialize( stream );
              stream.Close();
    
              // Deserialize the object and use it
              return tmp;
            }
          }
          catch( Exception ex )
          {
            string msg  = ex.Message;
            ex = ex.InnerException;
    
            while( ex != null )
            {
              msg += "" + ex.Message;
              ex = ex.InnerException;
            }
    
            System.Windows.Forms.MessageBox.Show( String.Format( "Exception reading {0}: {1}", FileWithPath, msg ) );
          }
    
          return new sventevitData();
        }
    
        
        private static void AddDirSecurity(     String Dir, 
                                                String Account,
                                                FileSystemRights Rights,
                                                AccessControlType AccessType )
        {
          // Create a new DirectoryInfo object.
          DirectoryInfo dInfo = new DirectoryInfo( Dir );
    
          // Get a DirectorySecurity object that represents the 
          // current security settings.
          DirectorySecurity dSecurity = dInfo.GetAccessControl();
    
          // Add the FileSystemAccessRule to the security settings. 
          dSecurity.AddAccessRule( new FileSystemAccessRule( Account, Rights, AccessType ) );
    
          // Set the new access settings.
          dInfo.SetAccessControl( dSecurity );
        }
      }
    
      [XmlType( AnonymousType = true )]
      public class DataGroup
      {
        [XmlAttribute]
        public string Type { get; set; }
    
        [XmlText( DataType = "base64Binary" )]
        public byte[] Value { get; set; }
      }
    [TestClass]
      public class sventevitDataTest
      {
        [TestMethod]
        [TestCategory( "StackOverflow" )]
        public void SerializeTest()
        {
          string fileWithPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
          fileWithPath        = Path.Combine( fileWithPath, "testData.xml" );
    
          sventevitData data = new sventevitData();
    
          data.Id         = "1";
          data.Status     = "OK";
          data.DataGroup  = new DataGroup()
          {
            Type    = "SomeType",
            Value   = new byte[]{ 0x00, 0x01, 0x02 }
          };
    
          data.SerializeData( fileWithPath );
        }
    
        
        [TestMethod]
        [TestCategory( "StackOverflow" )]
        public void DeserializeTest()
        {
          string fileWithPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
          fileWithPath        = Path.Combine( fileWithPath, "testData.xml" );
    
          sventevitData data = sventevitData.DeserializeData( fileWithPath );
        }
      }
