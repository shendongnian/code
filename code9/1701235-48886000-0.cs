    using UnityEngine;
    using System.Collections;
    
    public class Ritch: MonoBehaviour {
    
    
    public bool dragging = false;
    
    void Update () {
    
        if (PreRitch.Deathritch == true)
        {
    
            transform.position = new Vector3(8f,6.89f,9f);
    
        }
    
        //if (transform.position.x > 11.5 && dragging == false)
        if (transform.position.x > 11.5f && dragging == false)
        {
            //Application.LoadLevel(0);
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    
        }
        //else if (transform.position.x < 4.5 && dragging == false)
        else if (transform.position.x < 4.5f && dragging == false)
        {
            //Application.LoadLevel(0);
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    
        }
    
    
    
    }
    
    void OnMouseDown()
    {
    
        dragging = true;
    
    }
    
    void OnMouseUp()
    {
    
        dragging = false;
    
    }
    }
