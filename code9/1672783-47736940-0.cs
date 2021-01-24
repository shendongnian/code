    public class Queue_System_Of_Begin_Game : MonoBehaviour
      {
          private bool coroutineStarted;
      
          // Update is called once per frame
          void Update()
          {     
              if (!coroutineStarted && Game_Controller.Player1_First_throws_true && Game_Controller.Player2_First_throws_true)
              {
                  coroutineStarted = true ;
                  StartCoroutine(ExecuteAfterTime(1));     
              }     
          }
          //--------------------------------------
          public GameObject player1_icon, player2_icon, dice1_p1, dice2_p1, dice1_p2, dice2_p2;
          void determine_the_turn()
          {
              Debug.Log("update");
      
          }
      
          IEnumerator ExecuteAfterTime(float time)
          {
              yield return new WaitForSeconds(time);
      
              determine_the_turn();
          }
      }
