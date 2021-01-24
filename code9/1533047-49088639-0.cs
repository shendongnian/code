        private void ComponentSelectedFromPopUpMenu(Vector2 position, string menuPath) {
            
            
                        MonoScript monoScript;
            
                        char[] kPathSepChars = new char[]
                        {
                            '/',
                            '\\'
                        };
            
                        menuPath = menuPath.Replace(" ", "");
                        string[] pathElements = menuPath.Split(kPathSepChars);
            
                        string fileName = pathElements[pathElements.Length - 1].Replace(".cs", "");
            
            
            
            
                        if (pathElements[0] == "Assets") {
            
                            Debug.LogWarning("Unity need to compile new added file so can be included");
            
            
                        } else if (pathElements.Length == 2) {
            
    //use fileName
                            //do something
            
                            
                        } else if (pathElements[1] == "Scripts") {//Component/Scripts/MyScript.cs
                            
            
                            string[] guids = AssetDatabase.FindAssets("t:Script " + fileName.Replace(".cs", ""));
            
                            if (guids.Length > 0) {
            
                                for (int i = 0; i < guids.Length; i++) {
                                    monoScript = AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guids[i]), typeof(MonoScript)) as MonoScript;
                                    Type typet = monoScript.GetClass();
            
                                    if (typet == null) continue;
            
            
                                   
            
                        } else {//Component/Physics/Rigidbody
                            //try to find by type, cos probably Unity type
                            Type unityType = ReflectionUtility.GetType("UnityEngine." + fileName);
            
                            if (unityType != null) {
            
        //do something
            
                                return;
            
                            }
            
            
            
            
            
            //Based on attribute  [AddComponentMenu("Logic/MyComponent")] 
                            //Component/Logics/MyComponent
                            string[] guids = AssetDatabase.FindAssets("t:Script " + fileName.Replace(".cs", ""));
            
                            if (guids.Length > 0) {
            
                                for (int i = 0; i < guids.Length; i++) {
                                    monoScript = AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guids[i]), typeof(MonoScript)) as MonoScript;
                                    Type typet = monoScript.GetClass();
            
                                    if (typet == null) continue;
            
                                    object[] addComponentMenuAttributes = typet.GetCustomAttributes(typeof(AddComponentMenu), true);
            
            
            
                                    if (addComponentMenuAttributes != null && addComponentMenuAttributes.Length > 0 && "Component/" + ((AddComponentMenu)addComponentMenuAttributes[0]).componentMenu == menuPath)
                                    {
            
                                        //do somethings
            
                                    }
                                }
            
            
                            }
            
            
                        }
                    }
