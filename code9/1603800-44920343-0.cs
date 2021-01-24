    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEditor;
    using UnityEditor.SceneManagement;
    
    [CustomEditor(typeof(MapGenerator))]
    public class MapGeneratorEditor : Editor
    {
    
        static bool showMapProperties = true;
        static bool showTiles = true;
        private SerializedObject _target;
        SerializedProperty _mTiles;
        int _mTilesSize;
        MapGenerator myTarget;
    
    
        public override void OnInspectorGUI()
        {
    
            myTarget = (MapGenerator)target;
    
            //SerializedProperty _mySerializedTileList = _mySerializedTarget.FindProperty("tiles");
    
            showMapProperties = EditorGUILayout.Foldout(showMapProperties, new GUIContent("Map Properties", "Set different properties fot the map generation."));
    
            if (showMapProperties)
            {
                myTarget.width = EditorGUILayout.IntSlider(new GUIContent("Width", "Specify the width of the map"), myTarget.width, 1, 100);
                myTarget.height = EditorGUILayout.IntSlider(new GUIContent("Height", "Specify the height of the map"), myTarget.height, 1, 100);
            }
    
            showTiles = EditorGUILayout.Foldout(showTiles, new GUIContent("Tiles List", "Tiles that are used to generate the map"));
    
    
            if (showTiles)
            {
    
                _mTilesSize = myTarget.tiles.Count;
    
    
                for (int y = 0; y < _mTilesSize; y++)
                {
                    myTarget.tiles[y].tileType = (TileType)EditorGUILayout.EnumPopup("Tile Type", myTarget.tiles[y].tileType);
                    myTarget.tiles[y].tileTexture = (Sprite)EditorGUILayout.ObjectField(new GUIContent("Tile Texture", "Tile Texture"), myTarget.tiles[y].tileTexture, typeof(Sprite), false, null);
                    
                    GUILayout.Label("____________________________________________________________________________________________________________");
                }
    
    
                if (GUILayout.Button(new GUIContent("Add new Tile", "Click to add a new tile to the list")))
                {
                    Tile newTile = new Tile();
                    newTile.tileType = (TileType)EditorGUILayout.EnumPopup("Tile Type", TileType.NONE);
                    //newTile.tileType = (TileType)EditorGUILayout.EnumPopup(new GUIContent("Tile Type", "Type of selected tile"), newTile.tileType,GUIStyle.none,null);
                    newTile.tileTexture = (Sprite)EditorGUILayout.ObjectField(new GUIContent("Tile Texture", "Tile Texture"), newTile.tileTexture, typeof(Sprite), false, null);
                    //tiles.Add(newTile);
                    myTarget.tiles.Add(newTile);
                    
                }
    
                if (GUILayout.Button(new GUIContent("Remove Tile", "Click to remove the last tile in the list")))
                {
                    //myTarget.Invoke("RemoveTile", 0.0f);
                    //if (tiles.Count > 0)
                    //    tiles.RemoveAt(tiles.Count - 1);
    
                    if (myTarget.tiles.Count > 0)
                        myTarget.tiles.RemoveAt(myTarget.tiles.Count - 1);
                }
    
                if (GUILayout.Button(new GUIContent("Remove All Tiles", "Click to remove all tiles in the list")))
                {
                    myTarget.tiles.Clear();
                }
    
            }
            
            if(GUI.changed)
                EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    
    
        }
    
    
    }
