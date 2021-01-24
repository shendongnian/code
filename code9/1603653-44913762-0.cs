    public class CustomWindow : EditorWindow
    {
        #region Private Fields
        private Vector2 scrollLocation;
        private float elementsWidth;
        private float textBoxWidth;
        private float buttonWidth;
        private const int WINDOW_MIN_SIZE = 400;
        private const int BORDER_SPACING = 10;
        private const int ELEMENT_SPACING = 8;
        #endregion Private Fields
        #region Public Methods
        [MenuItem("Window/CustomWindow")]
        public static void ShowWindow()
        {
            CustomWindow window = GetWindow(typeof(CustomWindow), false, "CustomWindow") as CustomWindow;
            window.Show();
            window.minSize = new Vector2(WINDOW_MIN_SIZE, WINDOW_MIN_SIZE);
            window.Load();
        }
        #endregion Public Methods
        #region Private Methods
        private void OnGUI()
        {
            elementsWidth = EditorGUIUtility.currentViewWidth - BORDER_SPACING * 2;
            textBoxWidth = elementsWidth * 0.4f;
            buttonWidth = elementsWidth * 0.2f;
            scrollLocation = EditorGUILayout.BeginScrollView(scrollLocation);
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("stuff1", GUILayout.Width(largeWidth));
            EditorGUILayout.LabelField("stuff2", GUILayout.Width(largeWidth));
            EditorGUILayout.LabelField("stuff3", GUILayout.Width(smallwidth));
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndScrollView();
        }
        #endregion Private Methods
    }
