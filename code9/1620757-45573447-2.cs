    using System.Collections.Generic;
    using UnityEditor;
    using UnityEngine;
    
    [InitializeOnLoad]
    public class HierarchyPlus
    {
    
        static HierarchyPlus()
        {
            EditorApplication.hierarchyWindowItemOnGUI += HierarchyItemCB;
        }
    
        static Dictionary<int, string> instanceToBtnStr = new Dictionary<int, string>();
    
        private static void HierarchyItemCB(int instanceID, Rect selectionRect)
        {
            //Add key if it is not in the Dictionary yet
            if (!instanceToBtnStr.ContainsKey(instanceID))
            {
                //Add with Default On Key
                instanceToBtnStr.Add(instanceID, "On");
            }
    
            GameObject go = (GameObject)EditorUtility.InstanceIDToObject(instanceID);
            Rect rect = new Rect(selectionRect);
            rect.x = rect.width - 30;
            if (go != null)
            {
                GUI.skin.button.fixedWidth = 30;
    
                //Initialize btnStr from Dictionary
                string btnStr = instanceToBtnStr[instanceID];
    
                if (GUI.Button(rect, btnStr))
                {
                    Debug.Log(go.name);
                    if (go.activeSelf == true)
                    {
                        go.SetActive(false);
                        instanceToBtnStr[instanceID] = "Off";
                    }
                    else
                    {
                        go.SetActive(true);
                        instanceToBtnStr[instanceID] = "On";
                    }
                }
            }
        }
    
        // Use this for initialization
        void Start()
        {
    
        }
    
        // Update is called once per frame
        void Update()
        {
    
        }
    }
