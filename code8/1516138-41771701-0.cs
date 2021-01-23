    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Script.Serialization;
    using System.Windows.Forms;
    using System.Xml.Serialization;
    namespace WindowsFormsApplication6
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Class1 oClass = new Class1();
            DerivedV1 v1 = new DerivedV1();
            v1.Name = "DerivedV1";
            oClass.DerivedClasses.Add(v1);
            DerivedV2 v2 = new DerivedV2();
            v2.Name = "DerivedV2";
            oClass.DerivedClasses.Add(v2);
            DerivedV3 v3 = new DerivedV3();
            v3.Name = "DerivedV3";
            oClass.DerivedClasses.Add(v3);
            JavaScriptSerializer ser = new JavaScriptSerializer(new SimpleTypeResolver());
            string sSer = ser.Serialize(oClass);
            var test =ser.Deserialize(sSer,typeof(Class1));
            foreach (var tst in ((Class1)test).DerivedClasses)
            {
                Console.WriteLine(tst.Name + Environment.NewLine);
                Console.WriteLine(tst.GetType().ToString() + Environment.NewLine);
            }
        }
        public class Class1
        {
            public List<BaseClass> DerivedClasses { get; set; }
            public Class1()
            {
                DerivedClasses = new List<BaseClass>();
            }
        }
        public abstract class BaseClass
        {
            public string Name { get; set; }
            private bool _dosom;
            public abstract bool DoSomething();
            public BaseClass(){}
        }       
        public class DerivedV1 : BaseClass
        {
            public override bool DoSomething()
            {
                return true;
                // Logic here, different for each derived class.
            }
        }
        public class DerivedV2 : BaseClass
        {
            public override bool DoSomething()
            {
                return false;
                // Logic here, different for each derived class.
            }
        }
        public class DerivedV3 : BaseClass
        {
            public override bool DoSomething()
            {
                return true;
                // Logic here, different for each derived class.
            }
        }
    }
    }
