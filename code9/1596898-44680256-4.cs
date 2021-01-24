    #if !UNITY_EDITOR
    public class SomeTest
    {
      [RuntimeInitializeOnLoadMethod]
      static void OnInit() { Debug.Log("Does not show up"); }
    }
    #endif
