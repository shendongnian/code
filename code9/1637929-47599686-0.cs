    using System.ComponentModel.Design;
    using System.Linq;
    using System.Windows.Forms.Design;
    public class MyControlDesigner : ControlDesigner
    {
        DesignerVerbCollection verbs;
        public override DesignerVerbCollection Verbs
        {
            get
            {
                if (verbs == null)
                {
                    verbs = base.Verbs;
                    verbs.Add(new DesignerVerb("Show Select Resource", 
                        (s, e) => ShowSelectResource()));
                }
                return verbs;
            }
        }
        public void ShowSelectResource()
        {
            var editorServiceContext = typeof(ControlDesigner).Assembly.GetTypes()
                .Where(x => x.Name == "EditorServiceContext").FirstOrDefault();
            var editValue = editorServiceContext.GetMethod("EditValue",
                System.Reflection.BindingFlags.Static |
                System.Reflection.BindingFlags.Public);
            editValue.Invoke(null, new object[] { this, this.Component, "SomeProperty" });
        }
    }
