    public class TestA
    {
    #if UNITY_EDITOR
      [RuntimeInitializeOnLoadMethod] static void RuntimeInitWrapper() { /* Do Nothing */ }
      [UnityEditor.InitializeOnLoadMethod] static void EditorInitWrapper() { OnInit(); }
    #else
      [RuntimeInitializeOnLoadMethod] static void RuntimeInitWrapper() { OnInit(); }
    #endif
    
      static void OnInit() { Debug.Log("TEST A - This now prints in Standalone"); }
    }
