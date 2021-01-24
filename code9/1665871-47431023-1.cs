    [CustomEditor(typeof(MyBehaviourClass))]
    public class MyEditorClass : Editor
    {
        public override void OnInspectorGUI()
        {
            // If we call base the default inspector will get drawn too.
            // Remove this line if you don't want that to happen.
            base.OnInspectorGUI();
 
            MyBehaviourClass myBehaviour = target as MyBehaviourClass;
 
            target.myBool = EditorGUILayout.Toggle("myBool", target.myBool);
 
            if (target.myBool)
            {
                target.someFloat = EditorGUILayout.FloatField ("Some Float:", target.someFloat);
            }
        }
    }
