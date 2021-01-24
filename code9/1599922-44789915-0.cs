    using UnityEngine; 
    using System.Collections;
    
    public class Paddle : MonoBehaviour
    {
    
        public GameObject enemy;
    
        // Use this for initialization
        void Start()
        {
    
            enemy.SetActive(false);
        }
    
        // Update is called once per frame
        void Update()
        {
    
            Vector3 paddlePos = new Vector3(8f, this.transform.position.y, 0f);
    
            float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
    
            paddlePos.x = Mathf.Clamp(mousePosInBlocks, 6f, 8f);
    
            this.transform.position = paddlePos;
    
            if (mousePosInBlocks < 6f)
            {
                print("1");
    
            }
            else if (mousePosInBlocks <= 6.5f)
            {
                print("2");
    
                enemy.SetActive(true);
    
    
            }
            else if (mousePosInBlocks <= 7.5f)
            {
                print("3");
    
            }
            else
            {
              enemy.SetActive(false);
                print("4");
            }
        }
    }
