         public void TextID()
           {
             textID= (int)VD.nodeData.extraVars["cuadro"];
             print(textID);
                 switch (textID)
                 {
                   case 0:
                   break;
                   case 1:
                   StartCoroutine(LipsMoving(3));
                   break;
                   case 2:
                   StartCoroutine(LipsMoving(6));
                   break;
                 }
            }
            IEnumerator LipsMoving(int talkTime)
             {
              funcionesScript.Speaking();
              yield return new WaitForSeconds(talkTime);
              funcionesScript.Idle();
              yield return null;
             }
