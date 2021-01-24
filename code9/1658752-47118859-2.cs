     private IEnumerator MyCoroutine(Action<Texture2D> callback){
             yield return null; 
             Texture2D tex = GetTexture();
             if (callback !=null){callback(tex);}
      }
     void Start(){
            StartCoroutine(MyCoroutine((texParam)=>
           { 
                StartCoroutine(OtherCoroutine(texParam));
            }
      }
    IEnumerator OtherCoroutine(Texture2D texture){
           yield return null;
           texture.DoSomething();
     }
