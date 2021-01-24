    Drag your prefab to scene and attach a script to your Button `GameObject`:
        using UnityEngine;
        using UnityEngine.UI;
        public class MyButton : MonoBehaviour
        {
            public Text text;
            public Image image;
        }
    Then drag `1 Text` and `2 Image` to `text` and `image` field in the inspector of the Button.
    ![how][4]  
    Remember to press apply button and <kbd>Ctrl+S</kbd> to save that into your prefab.
    In this way you can access the text and image like:
        var mybutton = addTypeButton.GetComponent<MyButton>();
        mybutton.text.text = "Some string";
        mybutton.image.sprite = Sprite.Create(...);
