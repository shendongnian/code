    [CustomPropertyDrawer(typeof(MyScript))]
    public class MyScriptDrawer : PropertyDrawer
    {
    	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            //...
    		EditorGUI.BeginProperty(position, label, property);
    		EditorGUI.LabelField(new Rect(x, y, w, h), "title");
    		EditorGUI.PropertyField(rect, I, GUIContent.none);
            //...
        }
    }
