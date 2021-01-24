     public void StartGame()
     {
         Starting = true;
    
         CrossFadeAlphaWithCallBack(screen, 1f, fadeTime, delegate
          {
              Debug.Log("Done Fading");
              SceneManager.LoadScene(1);
          });
     }
    
     void CrossFadeAlphaWithCallBack(Image img, float alpha, float duration, System.Action action)
     {
         StartCoroutine(CrossFadeAlphaCOR(img, alpha, duration, action));
     }
    
     IEnumerator CrossFadeAlphaCOR(Image img, float alpha, float duration, System.Action action)
     {
         Color currentColor = img.color;
    
         Color visibleColor = img.color;
         visibleColor.a = alpha;
    
    
         float counter = 0;
    
         while (counter < duration)
         {
             counter += Time.deltaTime;
             img.color = Color.Lerp(currentColor, visibleColor, counter / duration);
             yield return null;
         }
    
         //Done. Execute callback
         action.Invoke();
     }
