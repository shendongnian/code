    using UnityAsync;
    using System.Threading.Tasks;
    
    public class UpdateLoop : MonoBehaviour
    {
        async void Start()
        {
            await WaitForMouseDown();
        }
    
        async Task WaitForMouseDown()
        {
            while(true)
            {
                print("Run Each frame right before rendering");
                await Await.NextUpdate(); // equivalent of AsyncBehaviour's NextUpdate
            }
        }
    }
