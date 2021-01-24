    public void ReturnKeyPressed()
    {
        switch(DialogueController.indexConversation)
        {
            case 3:
                Debug.Log("Fourth Option");
                telResponse.text = "Response 4";
                break;
        
            case 4:
                Debug.Log("Option 5");
                telResponse.text = "Response 5";
                break;
            default:
                break;
        }
    }
