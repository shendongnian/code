    namespace FirstPlugin
    {
        using System.ComponentModel.Composition;
        [Export(typeof(IPlugin))]
        public class NamePlugin : IPlugin
        {
            public void Initialize() { }
        }
    }
