     Score.text = Mathf.Round(score- Time.deltaTime*150).ToString(); 
   
 --
    public void Update () {
        
                Score.text = Mathf.Round(score- Time.deltaTime*150).ToString();
        
                if (gameOver)
                {
                    if (Input.GetKeyDown (KeyCode.Space))
                    {
                        SceneManager.LoadScene(1);
                    }
                }
            }
