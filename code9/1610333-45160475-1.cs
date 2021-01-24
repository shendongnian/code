    using UnityEngine;
    using System.Collections;
    using UnityEditor;
    
    public class CreatePacksInfo
    {
        [MenuItem("Assets/Create/Packs Info")]
        public static PacksInfo Create()
        {
            TextAsset json = (TextAsset) 
            AssetDatabase.LoadAssetAtPath("Assets/RawData/PacksInfo.json", 
            typeof(TextAsset));
            PacksInfo asset = ScriptableObject.CreateInstance<PacksInfo>();
            JsonUtility.FromJsonOverwrite(json.text, asset);
    
            AssetDatabase.CreateAsset(asset, "Assets/Data/PacksInfo.asset");
            AssetDatabase.SaveAssets();
            return asset;
        }
    }
