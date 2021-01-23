    [CustomEditor(typeof(ColorChanger))]
    public class CustomColorChangerInspector : Editor
    {
        // I like to declare it once for all but you can also call "(ColorChanger)target" each time to refer to the target
        private ColorChanger m_Target;
        public override void OnInspectorGUI()
        {
            m_Target = target as ColorChanger;
            for (int i = 0; i < ColorChanger.single.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();
                m_Target.single[i].gameObjectToChange = (GameObject)EditorGUILayout.ObjectField(m_Target.single[i].gameObjectToChange, typeof(GameObject));
                [...]
            }
        }
    }
