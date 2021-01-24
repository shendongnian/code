    [CustomEditor(typeof(TwoStateButton))]
    public class TwoStateButtonEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            switch(target.transitionMode)
            {
                case Automatic:
                    //Automatic code
                    [...]
                    break;
                case ColorTint:
                    //Color Tint code
                    [...]
                    break;
                default:
                    break;
            }
        }
    }
