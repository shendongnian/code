    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;
    using System.Xml;
    
    namespace Common
    {
        public class SimpleTask3 : Task
        {
            private string myProperty;
    
            // The [Required] attribute indicates a required property.
            // If a project file invokes this task without passing a value
            // to this property, the build will fail immediately.
            [Required]
            public string MyProperty
            {
                get
                {
                    return myProperty;
                }
                set
                {
                    myProperty = value;
                }
            }
    
            public override bool Execute()
            {
                // Log a high-importance comment
                Log.LogMessage(MessageImportance.High, "The task was passed \"" + myProperty + "\"");
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(myProperty + "/web.base.config");
    
                XmlDocument sDoc = new XmlDocument();
                sDoc.Load(myProperty + "/ConfigBuild/Web.DevServer1.config");
    
                //compare with them and check the different.
    
                //if different
    
                Log.LogMessage(MessageImportance.High, "different message");
                return true;
            }
        }
    }
