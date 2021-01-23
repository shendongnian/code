    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;
    
    public class ExampleScene1 : MonoBehaviour
    {
        InputField input1;
        InputField input2;
    
        void Awake()
        {
            //input1 = something...;
            //input2 = something...;
        }
    
        void LoadScene2()
        {
            ExampleUserData.MyUserData1 = input1.text;
            ExampleUserData.MyUserData2 = input2.text;
    
            SceneManager.LoadScene("Scene2");
        }
    }
