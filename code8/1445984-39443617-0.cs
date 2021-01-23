    using System.Drawing;
    using System.Reflection;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Reflection;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraEditors.Registrator;
    using DevExpress.XtraEditors.Drawing;
    using DevExpress.XtraEditors.ViewInfo;
    using DevExpress.Accessibility;
    
    namespace DevExpress.CustomEditors {
    
        //The attribute that points to the registration method 
        [UserRepositoryItem("RegisterCustomEdit")]
        public class RepositoryItemCustomEdit : RepositoryItemTextEdit {
            
            //The static constructor that calls the registration method 
            static RepositoryItemCustomEdit() { RegisterCustomEdit(); }
    
            //Initialize new properties 
            public RepositoryItemCustomEdit() {            
                useDefaultMode = true;
            }
    
            //The unique name for the custom editor 
            public const string CustomEditName = "CustomEdit";
    
            //Return the unique name 
            public override string EditorTypeName { get { return CustomEditName; } }
            
            //Register the editor 
            public static void RegisterCustomEdit() {
                //Icon representing the editor within a container editor's Designer 
                Image img = null;
                try {
                    img = (Bitmap)Bitmap.FromStream(Assembly.GetExecutingAssembly().
                      GetManifestResourceStream("DevExpress.CustomEditors.CustomEdit.bmp"));
                }
                catch {
                }
                EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName, 
                  typeof(CustomEdit), typeof(RepositoryItemCustomEdit), 
                  typeof(TextEditViewInfo), new TextEditPainter(), true, img, typeof(TextEditAccessible)));
            }
               
            //A custom property 
            private bool useDefaultMode;
    
            public bool UseDefaultMode {
                get { return useDefaultMode; }
                set {
                    if(useDefaultMode != value) {
                        useDefaultMode = value;                        
                        OnPropertiesChanged();
                    }
                }
            }
    
            //Override the Assign method 
            public override void Assign(RepositoryItem item) {
                BeginUpdate(); 
                try {
                    base.Assign(item);
                    RepositoryItemCustomEdit source = item as RepositoryItemCustomEdit;
                    if(source == null) return;
                    useDefaultMode = source.UseDefaultMode;
                }
                finally {
                    EndUpdate();
                }
            }
        }
    
        [ToolboxItem(true)]
        public class CustomEdit : TextEdit {
            
            //The static constructor that calls the registration method 
            static CustomEdit() { RepositoryItemCustomEdit.RegisterCustomEdit(); }
    
            //Initialize the new instance 
            public CustomEdit() {
                //... 
            }
    
            //Return the unique name 
            public override string EditorTypeName { get { return 
                RepositoryItemCustomEdit.CustomEditName; } }
    
            //Override the Properties property 
            //Simply type-cast the object to the custom repository item type 
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            public new RepositoryItemCustomEdit Properties {
                get { return base.Properties as RepositoryItemCustomEdit; }
            }
                
        }
    }
