    using UnityEngine;
    public class SkyboxPulse : MonoBehaviour
    {
        public float pulseRate = 0.2f;
    
        void Update()
        {
            float exposure = RenderSettings.skybox.GetFloat("_Exposure");
    
            if (exposure < 0.1 || exposure > 1.9)
                pulseRate = -pulseRate;
    
            RenderSettings.skybox.SetFloat("_Exposure", exposure + pulseRate * Time.deltaTime);
            print(RenderSettings.skybox.GetFloat("_Exposure"));
        }
    }
