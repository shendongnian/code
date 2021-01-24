    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Networking;
    using UnityEditor;
    
    public class CheckUNETSceneRegistered : ScriptableObject {
    
        const string menuName = "UNET SceneObjects Registration Check";
    
        [MenuItem("Tools/Check UNET SceneObjects are Registered")]
        static void DoCheck()
        {
            
            NetworkManager networkManager = FindObjectOfType<NetworkManager>();
    
            if(networkManager == null)
            {
                EditorUtility.DisplayDialog(menuName, "No NetworkManager found", "OK", "");
                return;
            }
    
    
            List<string> registeredPrefabNames = new List<string>(networkManager.spawnPrefabs.Count);
            foreach (GameObject g in networkManager.spawnPrefabs)
                registeredPrefabNames.Add(g.name);
    
            int i = 0;
            foreach (NetworkIdentity uv in FindObjectsOfType<NetworkIdentity>())
            {
                if (!registeredPrefabNames.Contains(PrefabUtility.GetPrefabParent(uv.gameObject).name))
                {
                    Debug.LogError("Found " + uv.name + " in the scene, but its prefab " + PrefabUtility.GetPrefabParent(uv.gameObject).name + " was not registered");
                    i++;
                }
            }
    
            EditorUtility.DisplayDialog(menuName, ( i>0 ? "Found " + i + " unregistered Scene Objects.  See Logs." : "All OK" ), "OK", "");
        }
    }
