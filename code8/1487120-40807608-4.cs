    using UnityEngine;
    using UnityEditor;
    
    namespace BoxStairsTool
    {
        [CustomEditor(typeof(BoxStairs))]
        public sealed class BoxStairsEditor : Editor
        {
            private const string DefaultName = "BoxStairs";
    
            [MenuItem("GameObject/3D Object/BoxStairs")]
            private static void CreateBoxStairsGO ()
            {
    			GameObject BoxStairs = new GameObject(DefaultName);
    			BoxStairs.AddComponent<BoxStairs>();
    
    			if (Selection.transforms.Length == 1)
    			{
    				BoxStairs.transform.SetParent(Selection.transforms[0]);
    				BoxStairs.transform.localPosition = new Vector3(0,0,0);
    			}
    
    			Selection.activeGameObject = BoxStairs;
    			Undo.RegisterCreatedObjectUndo(BoxStairs, "Create BoxStairs");
            }
    
            private void OnEnable ()
            {
    			EditorApplication.update += Update;
            }
    
            public override void OnInspectorGUI ()
            {
                if (GUILayout.Button("Finalize stairs"))
                {
    				needFinalize = true;
                }
            }
    
            private void FinalizeStairs ()
            {
                Undo.SetCurrentGroupName("Finalize stairs");
                BoxStairs script = (BoxStairs)target;
                GameObject go = script.gameObject;
                BoxCollider bc = go.GetComponent<BoxCollider>();
    
                if (bc != null)
                {
                    Undo.DestroyObjectImmediate(bc);
                }
                Undo.DestroyObjectImmediate(target);
            }
    
    		bool needFinalize;
    		void Update()
    		{
    			if(needFinalize)
    			{
    				FinalizeStairs();
    				needFinalize = false;
    				EditorApplication.update -= Update;
    			}
    		}
        }
    }
