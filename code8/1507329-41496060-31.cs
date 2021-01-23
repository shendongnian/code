    public class DialogueHolder{
        // The message they'll say
        public string MessageToSay;
    
    }
   
    ...
    
    // Then we *instance* one for each of our NPCs:
    DialogueHolder yellowMage=new DialogueHolder();
    yellowMage.MessageToSay="I'm feeling great!";
    
    DialogueHolder redMage=new DialogueHolder();
    redMage.MessageToSay="I'm so angry!";
    ..
