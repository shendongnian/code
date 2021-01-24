    public class TestA
    {
      [RuntimeInitializeOnLoadMethod]
    #if UNITY_EDITOR
      static void OnInitWrapper() { /* Do not run in editor*/ }
    #else
      static void OnInitWrapper() { OnInit(); }
    #endif
    
    #if UNITY_EDITOR
      [UnityEditor.InitializeOnLoadMethod]
    #endif
      static void OnInit() { Debug.Log("TEST A - This now prints in Standalone"); }
    }
