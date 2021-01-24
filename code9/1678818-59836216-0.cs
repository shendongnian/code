    using System.Threading.Tasks;
    using UnityEngine;
    public class AsyncYieldTest : MonoBehaviour
    {
        async void Start()
        {
            await Function();
        }
        
        async Task Function() {
            while (gameObject != null)
            {
                await Task.Yield();
                Debug.Log("Frame: " + Time.frameCount);
            }
        }  
    }
