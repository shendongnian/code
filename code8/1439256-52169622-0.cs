    using UnityEngine.UI;
    public class SliderExample : MonoBehaviour
    {
        public Slider slider;  // Drag and Drop Slider GameObject in Unity Inspector
        float percentageCompleted;
        void Update()
        {
            slider.value = percentageCompleted;  
            // specify percentage Completed, if required Divide by 100 as Slider values are from 0 to 1 or set Max Value in Inspector as 100
        }
    }
