    using UnityAsync;
    using System.Threading.Tasks;
    
    public class UpdateLoop : MonoBehaviour
    {
        async void Start()
        {
            await RunEachFrame();
        }
    
        async Task RunEachFrame()
        {
            while(true)
            {
                print("Run Each frame right before rendering");
                await Await.NextUpdate(); // equivalent of AsyncBehaviour's NextUpdate
            }
        }
    }
