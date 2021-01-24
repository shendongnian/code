    namespace FirstPlugin
    {
        using System.ComponentModel.Composition;
        [Export(typeof(IPlugin))]
        public class NamePlugin : IPlugin
        {
            public string GetName() => GetType().Name;
        }
    }
