    public class TextControl : MonoBehaviour {
       List<string> questions = new List<string>() {"When does time fly?","When does time?","When does?"};
       List<string> CorrectAnswer = new List<string>() {"3","3","3"};
       public static string SelectedAnswer;
       public static string ChoiceSelected="n";
       public static int numberquestion=0;
       
       public int myNumberQuestion;
        // Use this for initialization
       void Start () {
       GetComponent<TextMesh> ().text = questions [numberquestion];
       }
       // Update is called once per frame
       void Update () 
       {
           if (ChoiceSelected == "y") 
       {
        if (CorrectAnswer [numberquestion] == SelectedAnswer) 
        {
            Debug.Log("Correct");
            myNumberQuestion = ++numberquestion;
            }
        }
    }
}
