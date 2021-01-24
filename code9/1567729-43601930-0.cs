    using System.Collections;
    using UnityEngine.UI;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Collection : MonoBehaviour {
    
    private int Parts;
    public Text CountPart;
    private string Amount;
    public GameObject collectedGameObject;
    void Start ()
    {
        Parts = 0;
        SetPartText();
    }
    
    // Update is called once per frame
    void Update () {
        if (Parts == 10)
        {
            Application.LoadLevel("DONE");
        }
    }
    
    void OnMouseDown ()
    {
            //here you need to initialize the collectedGameObject who is collected. you can use Raycasts or Colliders to get the refrences.
        collectedGameObject.SetActive(false);
        Parts = Parts + 1;
        SetPartText();
    }
    
    void SetPartText ()
    {
        Amount = Parts.ToString () + "/10";
        CountPart.text = "Rocket Parts Collected: " + Amount;
    
    }
    }
