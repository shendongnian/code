    using System;
    using System.Windows.Forms;
    using System.Xml;
    using System.IO;
    using System.Resources;
    
     private void LoadRDLCFromResources()
            {
                //Declare variables
    
                XmlDocument objXmlDocument = new XmlDocument();
                Byte[] byteArray;
                Stream objStream = null;
                ResourceManager resourceManager = null;
    
                try
                {
                    // Initialize ResourceManager object
                    resourceManager = new ResourceManager("your_namespace_name.Properties.Resources", GetType().Assembly);
                    if (resourceManager != null)
                    {
                        //Load the resource file "Sample.rdlc" into ByteArray
                        byteArray = (Byte[])resourceManager.GetObject("Sample");
                        if (byteArray != null)
                        {
                            //Load this bytearray into MemoryStream
                            objStream = new MemoryStream(byteArray);
                            if (byteArray.Length > 0)
                            {
                                //Load this stream object into XML document and  
                                //thus you get the rdlc file loaded as an XML 
                                //document. 
                                objXmlDocument.Load(objStream);
    
                                // Code for using this xml document as per your use
                            }
                        }
                    }
                }
    //MissingManifestResourceException is an exception thrown when the resource manager fails to initialize appropriately. In such case, please check the namespace name.
                catch (MissingManifestResourceException ex)
                {
    
                    MessageBox.Show("Exception -> " + ex.Message,
                       "Sample Demo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception -> " + ex.Message,
                        "Sample Demo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Clear the objects in finally block. This is required for memory management issues.
                    // If xml document is not required further then clear it in the following manner
                    if (objXmlDocument != null)
                    {
                        objXmlDocument.DocumentElement.RemoveAllAttributes();
                        objXmlDocument.DocumentElement.RemoveAll();   
    
                        objXmlDocument.RemoveAll();
                    }
                    //Clear the memory stream object 
                    if (objStream != null)
                    {
                        objStream.Flush();
                        objStream.Close();
                        objStream.Dispose();
                    }
                    // Clear resource manager 
                    resourceManager.ReleaseAllResources();
                }
            }
