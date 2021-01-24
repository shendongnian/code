    public class TestA
    {
      [RuntimeInitializeOnLoadMethod] static void RuntimeInitWrapper() 
      {
    #if !UNITY_EDITOR
        OnInit();
    #endif
      }
    #if UNITY_EDITOR
      [UnityEditor.InitializeOnLoadMethod]
    #endif
      static void OnInit() { Debug.Log("TEST A - This now prints in Standalone"); }
    }
