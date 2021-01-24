    public class HideVirtualKeyboard : InputField
    {
        protected override void Start()
        {
            keyboardType = (TouchScreenKeyboardType)(-1);
            base.Start();
        }
    }
