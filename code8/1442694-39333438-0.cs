    public class ExampleClass : MonoBehaviour {
        IEnumerator Start() 
        {
            AsyncOperation async = Application.LoadLevelAsync("MyBigLevel");
            yield return async;
            Debug.Log("Loading complete");
            // CALL THE CODE TO HIDE THE BANNER AT THIS POINT 
        }
    }
