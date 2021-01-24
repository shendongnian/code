    using System.Reflection;
    using System.IO;
    using System.Resources;
    using System.Media;
    using System.Diagnostics;
    namespace Yournamespace
    {
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            Assembly assembly;
            Stream soundStream;
            SoundPlayer sp;
            assembly = Assembly.GetExecutingAssembly();
            sp = new SoundPlayer(assembly.GetManifestResourceStream
                ("Yournamespace.Dreamer.wav"));
            sp.Play();  
        } 
    }
    }
