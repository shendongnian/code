    using UnityEngine;
    using UnityEditor;
    using System.Reflection;
    using System.IO;
    using System.Collections.Generic;
    using System.Text;
    using System;
    
    public class IconAssignmentPostProcessor : AssetPostprocessor
    {
        // Called when Editor Starts
        static IconAssignmentPostProcessor()
        {
            prepareSettingsDir();
            reloadAllFancyIcons();
        }
    
        private static string settingsPath = Application.dataPath + "/FancyIconSettings.text";
        private static string fancyIconPath = "Assets/Iconfolder/MyFancyIcon.png";
    
        private static bool firstRun = true;
    
        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            prepareSettingsDir();
    
            //Load old settings 
            FancyIconSaver savedFancyIconSaver = LoadSettings();
    
    
            Texture2D icon = AssetDatabase.LoadAssetAtPath<Texture2D>(fancyIconPath);
    
            for (int j = 0; j < importedAssets.Length; j++)
            {
                string asset = importedAssets[j];
    
                MonoScript script = AssetDatabase.LoadAssetAtPath<MonoScript>(asset);
                if (script != null)
                {
                    //Apply fancy Icon
                    ApplyIcon(script, icon);
    
                    //Process each asset 
                    processFancyIcon(savedFancyIconSaver, fancyIconPath, asset, pathToGUID(asset));
                }
            }
    
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    
    
        public static string pathToGUID(string path)
        {
            return AssetDatabase.AssetPathToGUID(path);
        }
    
        public static string guidToPath(string guid)
        {
            return AssetDatabase.GUIDToAssetPath(guid);
        }
    
        public static void processFancyIcon(FancyIconSaver oldSettings, string fancyIconPath, string scriptPath, string scriptGUID)
        {
            int matchIndex = -1;
    
            if (oldSettings == null)
            {
                oldSettings = new FancyIconSaver();
            }
    
            if (oldSettings.fancyIconData == null)
            {
                oldSettings.fancyIconData = new List<FancyIconData>();
            }
    
            FancyIconData fancyIconData = new FancyIconData();
            fancyIconData.fancyIconPath = fancyIconPath;
            fancyIconData.scriptPath = scriptPath;
            fancyIconData.scriptGUID = scriptGUID;
    
            //Check if this guid exist in the List already. If so, override it with the match index
            if (containsGUID(oldSettings, scriptGUID, out matchIndex))
            {
                oldSettings.fancyIconData[matchIndex] = fancyIconData;
            }
            else
            {
                //Does not exist, add it to the existing one
                oldSettings.fancyIconData.Add(fancyIconData);
            }
    
            //Save the data
            SaveSettings(oldSettings);
    
            //If asset does not exist, delete it from the json settings
            for (int i = 0; i < oldSettings.fancyIconData.Count; i++)
            {
                if (!assetExist(scriptPath))
                {
                    //Remove it from the List then save the modified List
                    oldSettings.fancyIconData.RemoveAt(i);
                    SaveSettings(oldSettings);
                    Debug.Log("Asset " + scriptPath + " no longer exist. Deleted it from JSON Settings");
                    continue; //Continue to the next Settings in the List
                }
            }
        }
    
        //Re-loads all the fancy icons
        public static void reloadAllFancyIcons()
        {
            if (!firstRun)
            {
                firstRun = false;
                return; //Exit if this is not first run
            }
    
            //Load old settings 
            FancyIconSaver savedFancyIconSaver = LoadSettings();
    
            if (savedFancyIconSaver == null || savedFancyIconSaver.fancyIconData == null)
            {
                Debug.Log("No Previous Fancy Icon Settings Found!");
                return;//Exit
            }
    
    
            //Apply Icon Changes
            for (int i = 0; i < savedFancyIconSaver.fancyIconData.Count; i++)
            {
                string asset = savedFancyIconSaver.fancyIconData[i].scriptPath;
    
                //If asset does not exist, delete it from the json settings
                if (!assetExist(asset))
                {
                    //Remove it from the List then save the modified List
                    savedFancyIconSaver.fancyIconData.RemoveAt(i);
                    SaveSettings(savedFancyIconSaver);
                    Debug.Log("Asset " + asset + " no longer exist. Deleted it from JSON Settings");
                    continue; //Continue to the next Settings in the List
                }
    
                string tempFancyIconPath = savedFancyIconSaver.fancyIconData[i].fancyIconPath;
    
                Texture2D icon = AssetDatabase.LoadAssetAtPath<Texture2D>(tempFancyIconPath);
                MonoScript script = AssetDatabase.LoadAssetAtPath<MonoScript>(asset);
                if (script == null)
                {
                    continue;
                }
    
                Debug.Log(asset);
                ApplyIcon(script, icon);
            }
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    
        private static void ApplyIcon(MonoScript script, Texture2D icon)
        {
            PropertyInfo inspectorModeInfo = typeof(SerializedObject).GetProperty("inspectorMode", BindingFlags.NonPublic | BindingFlags.Instance);
            SerializedObject serializedObject = new SerializedObject(script);
            inspectorModeInfo.SetValue(serializedObject, InspectorMode.Debug, null);
            SerializedProperty iconProperty = serializedObject.FindProperty("m_Icon");
            iconProperty.objectReferenceValue = icon;
            serializedObject.ApplyModifiedProperties();
            serializedObject.Update();
            EditorUtility.SetDirty(script);
            Debug.Log("Applied Fancy Icon to: " + script.name);
        }
    
        //Creates the Settings File if it does not exit yet
        private static void prepareSettingsDir()
        {
            if (!File.Exists(settingsPath))
            {
                File.Create(settingsPath);
            }
        }
    
        public static void SaveSettings(FancyIconSaver fancyIconSaver)
        {
            try
            {
                string jsonData = JsonUtility.ToJson(fancyIconSaver, true);
                Debug.Log("Data: " + jsonData);
    
                byte[] jsonByte = Encoding.ASCII.GetBytes(jsonData);
                File.WriteAllBytes(settingsPath, jsonByte);
            }
            catch (Exception e)
            {
                Debug.Log("Settings not Saved: " + e.Message);
            }
        }
    
        public static FancyIconSaver LoadSettings()
        {
            FancyIconSaver loadedData = null;
            try
            {
                byte[] jsonByte = File.ReadAllBytes(settingsPath);
                string jsonData = Encoding.ASCII.GetString(jsonByte);
                loadedData = JsonUtility.FromJson<FancyIconSaver>(jsonData);
                return loadedData;
            }
            catch (Exception e)
            {
                Debug.Log("No Settings Loaded: " + e.Message);
            }
            return loadedData;
        }
    
        public static bool containsGUID(FancyIconSaver fancyIconSaver, string guid, out int matchIndex)
        {
            matchIndex = -1;
    
            if (fancyIconSaver == null || fancyIconSaver.fancyIconData == null)
            {
                Debug.Log("List is null");
                return false;
            }
    
            for (int i = 0; i < fancyIconSaver.fancyIconData.Count; i++)
            {
                if (fancyIconSaver.fancyIconData[i].scriptGUID == guid)
                {
                    matchIndex = i;
                    return true;
                }
            }
            return false;
        }
    
        public static bool assetExist(string path)
        {
            return File.Exists(path);
        }
    
        [Serializable]
        public class FancyIconSaver
        {
            public List<FancyIconData> fancyIconData;
        }
    
        [Serializable]
        public class FancyIconData
        {
            public string fancyIconPath;
            public string scriptPath;
            public string scriptGUID;
        }
    }
