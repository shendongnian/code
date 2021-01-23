    using UnityEngine;
    using UnityEngine.UI;
    
    public class ExampleScene2 : MonoBehaviour
    {
        InputField input1;
        InputField input2;
    
        void Awake()
        {
            //input1 = something...;
            //input2 = something...;
        }
    
        void Start()
        {
            input1.text = ExampleUserData.MyUserData1;
            input2.text = ExampleUserData.MyUserData2;
        }
    }
