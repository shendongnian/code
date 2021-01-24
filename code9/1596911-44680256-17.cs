    public class TestA
    {
    #if UNITY_EDITOR
      [UnityEditor.InitializeOnLoadMethod] static void EditorInitWrapper() { OnInit(); }
      [RuntimeInitializeOnLoadMethod] static void RuntimeInitWrapper() { /* Do Nothing */ }
    #else
      [RuntimeInitializeOnLoadMethod] static void RuntimeInitWrapper() { OnInit(); }
    #endif
    
      static void OnInit() { Debug.Log("TEST A - This now prints in Standalone"); }
    }
