    using UnityEngine.SceneManagement;
    
    ...
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            SceneManager.LoadScene ("SceneName");
            //Or:
            //SceneManager.LoadScene (SceneIndex); //(without these: ", because it's a number - an int, not a string)
        }
    }
