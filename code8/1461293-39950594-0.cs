    using System.Windows.Forms;
    using System.Drawing;
    namespace TestApp
    {
        public class TheButton : Button
        {
            public void ChangeColor()
            {
                ForeColor = (Text == "true")  ? Color.Blue : Color.Red ;
            }
        }
    }
