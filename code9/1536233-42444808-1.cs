    [CustomEditor(typeof(WayPointScript))]
    public class TextDrawer : Editor
    {
    
        void OnSceneGUI()
        {
    
            Debug.Log("Running");
            WayPointScript t = target as WayPointScript;
    
            //Create Text on each checkpoint //
            for (int i = 0; i < t.waypoints.Length; i++)
            {
                UnityEditor.Handles.Label(t.waypoints[i].transform.position, (i + 1).ToString());
            }
        }
    }
