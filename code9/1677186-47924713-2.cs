    using System.Collections.Generic;
    using UnityEngine;
    using System;
    using UnityEngine.SceneManagement;
    
    #if UNITY_EDITOR
    using UnityEditor;
    #endif
    
    public class ComponentDetector : MonoBehaviour
    {
        //Add the blacklisted Components here
        private static Type[] blacklistedComponents =
            {
            typeof(Rigidbody),
            typeof(Rigidbody2D)
            //...
        };
    
        private static List<Component> allComponents = new List<Component>();
        private static List<GameObject> rootGameObjects = new List<GameObject>();
    
        private static void GetAllRootObject()
        {
            Scene activeScene = SceneManager.GetActiveScene();
            activeScene.GetRootGameObjects(rootGameObjects);
        }
    
        private static void GetAllComponentsAndCheckIfBlacklisted()
        {
            for (int i = 0; i < rootGameObjects.Count; ++i)
            {
                GameObject obj = rootGameObjects[i];
                //Debug.Log(obj.name);
    
                //Get all child components attached to this GameObject
                obj.GetComponentsInChildren<Component>(true, allComponents);
    
                //Remove component if present in the blacklist array
                RemoveComponentIfBlacklisted(allComponents, blacklistedComponents);
            }
    
    
        }
    
        private static void RemoveComponentIfBlacklisted(List<Component> targetComponents, Type[] blacklistedList)
        {
            //Loop through each target Component
            for (int i = 0; i < targetComponents.Count; i++)
            {
                //Debug.Log(targetComponents[i].GetType());
                //Loop through each blacklisted Component and see if it is present
                for (int j = 0; j < blacklistedList.Length; j++)
                {
                    if (targetComponents[i].GetType() == blacklistedList[j])
                    {
                        Debug.Log("Found Blacklisted Component: " + targetComponents[i].GetType().Name);
                        Debug.LogError("You are not allowed to add the " + targetComponents[i].GetType().Name + " component to a GameObject");
                        Debug.Log("Removing Blacklisted Component");
                        //Destroy Component
                        DestroyImmediate(targetComponents[i]);
    
                        Debug.LogWarning("This component is now destroyed");
                    }
                }
            }
        }
    
        public static void SearchAndRemoveblacklistedComponents()
        {
            //Get all root GameObjects
            GetAllRootObject();
    
            //Get all child components attached to each GameObject and remove them
            GetAllComponentsAndCheckIfBlacklisted();
        }
    
        void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }
    
        // Update is called once per frame
        void Update()
        {
            //Debug.Log("Update: Run-time");
            SearchAndRemoveblacklistedComponents();
        }
    }
    
    #if UNITY_EDITOR
    [InitializeOnLoad]
    class ComponentDetectorEditor
    {
        static ComponentDetectorEditor()
        {
            createComponentDetector();
            EditorApplication.update += Update;
        }
    
        static void Update()
        {
            //Debug.Log("Update: Editor");
            ComponentDetector.SearchAndRemoveblacklistedComponents();
        }
    
        static void createComponentDetector()
        {
            GameObject obj = GameObject.Find("___CDetector___");
            if (obj == null)
            {
                obj = new GameObject("___CDetector___");
            }
    
            //Hide from the Editor
            obj.hideFlags = HideFlags.HideInHierarchy;
            obj.hideFlags = HideFlags.HideInInspector;
    
            ComponentDetector cd = obj.GetComponent<ComponentDetector>();
            if (cd == null)
            {
                cd = obj.AddComponent<ComponentDetector>();
            }
    
        }
    }
    #endif
