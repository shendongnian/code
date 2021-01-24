    public delegate void ShootEventHandler(object sender, ShootEventArgs e);
    public class ShootEventArgs
    {
        public ShootEventArgs(string s) { Text = s; }
        public String Text {get; private set;} // readonly
    }
