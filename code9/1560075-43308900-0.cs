    Drag your prefab to scene and attach a script to your Button `GameObject`:
        using UnityEngine;
        public class MyButton : MonoBehaviour
        {
            public Text text;
            public Imageimage;
        }
    Then drag `1 Text`'s Text component and `2 Image`'s Image component from their inspector to text and image field in the inspector of the Button GameObject. (You can drag the component header in the inspector to a field of the same type). Press apply button and <kbd>Ctrl+S</kbd> to save that into your prefab.
    In this way you can access the text and image like:
        var mybutton = addTypeButton.GetComponent<MyButton>();
        mybutton.text = "Some string";
        mybutton.image = Sprite.Create(...);
