    [InitializeOnLoad]
    public class HierarchyPlus{
    
        static HierarchyPlus()
        {
            EditorApplication.hierarchyWindowItemOnGUI += HierarchyItemCB;
        }
    
        static string btnStr = "On";
    
        private static void HierarchyItemCB(int instanceID, Rect selectionRect)
        {
            GameObject go = (GameObject)EditorUtility.InstanceIDToObject(instanceID);
            Rect rect = new Rect(selectionRect);
            rect.x = rect.width - 30;
            if (go != null)
            {
                GUI.skin.button.fixedWidth = 30;
    
                if (GUI.Button(rect, btnStr))
                {
                    Debug.Log(go.name);
                    if (go.activeSelf == true)
                    {
                        go.SetActive(false);
                        btnStr = "Off";
                    }
                    else
                    {
                        go.SetActive(true);
                        btnStr = "On";
                    }
                }
            }               
        }    
    
        // Use this for initialization
        void Start () {
    
        }
    
        // Update is called once per frame
        void Update () {
    
        }
    }
