        List<string> pluginsNotUsed = new List<string>();
        UnityEditor.PluginImporter[] importers = UnityEditor.PluginImporter.GetAllImporters();
        for(int i = 0; i < importers.Length; i++)
        {
            if(!pluginsNotUsed.Contains(importers[i].assetPath))
            {
                pluginsNotUsed.Add(importers[i].assetPath);
            }
        }
        // ---- This part removes the plugins that match the current targeted build platform
        importers = UnityEditor.PluginImporter.GetImporters(UnityEditor.EditorUserBuildSettings.activeBuildTarget);
        for(int i = 0; i < importers.Length; i++)
        {
            if(pluginsNotUsed.Contains(importers[i].assetPath))
            {
                pluginsNotUsed.Remove(importers[i].assetPath);
            }
        }
        // ----
        Object obj = null;
        for(int i = 0; i < pluginsNotUsed.Count; i++)
        {
            // Remove this condition if you want to display all the loaded plugins
            // (including the ones installed withy Unity: C:/Program Files/Unity/Editor/Data/UnityExtensions/Unity/...)
            if(pluginsNotUsed[i].StartsWith("Assets/"))
            {
                obj = UnityEditor.AssetDatabase.LoadAssetAtPath(pluginsNotUsed[i], UnityEditor.AssetDatabase.GetMainAssetTypeAtPath(pluginsNotUsed[i]));
                Debug.Log(pluginsNotUsed[i], obj);
            }
        }
