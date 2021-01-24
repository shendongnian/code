var type = Type.GetType("System.AppContext");
if (type != null) {
    var setSwitch = type.GetMethod("SetSwitch", BindingFlags.Public | BindingFlags.Static);
    setSwitch.Invoke(null, new object[] { "Switch.System.IO.UseLegacyPathHandling", false });
    setSwitch.Invoke(null, new object[] { "Switch.System.IO.BlockLongPaths", false });
}
I have used this code in my application, but the value inside the `setSwitch` to which should I compare for long path 
