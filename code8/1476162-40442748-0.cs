     using UnityEngine;
        using System.Collections;
        using UnityEngine.UI;
    
        public class CreateHolder : MonoBehaviour {
    
        public InputField Input1;
        public InputField Input2;
        public InputField Input3;
        public InputField Input4;
        public ToggleGroup Discount;
        public ToggleGroup Params;
        public ToggleGroup Time;
    
    
        public void Grabdata() {
    
        PlayerPrefs.SetString("Offername", Input1.text);
        if (PlayerPrefs.HasKey("Offername") == true) 
        {
                Debug.Log("something has saved");
                Debug.Log(PlayerPrefs.GetString("Input1"));
        }
    
        PlayerPrefs.SetString("Offerdesc", Input2.text);
        PlayerPrefs.SetString("Offeramount", Input3.text);
        PlayerPrefs.SetString("Offerpercent", Input4.text);
        PlayerPrefs.SetString("Tog1", Discount.GetComponent<GUIText>().text);
        PlayerPrefs.SetString("Tog2", Params.GetComponent<GUIText>().text);
        PlayerPrefs.SetString("Tog3", Time.GetComponent<GUIText>().text);
        }
        }
