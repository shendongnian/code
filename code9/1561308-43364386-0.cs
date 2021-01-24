    [SerializeField]
    private YOUR_OTHER_SCRIPT_CLASS otherScript;
    if (Input.GetKey(KeyCode.Return))
    {
        showConversation = false;
        switch(indexConversation)
        {
            case 0:
                Debug.Log("first Option");
                telResponse.text = "Response 1"; 
                Conv1Controller.Conv1showConversation = true;
                indexConversation = 3;
                Debug.Log (indexConversation);
                break;
        
            case 1:
                Debug.Log("second Option");
                telResponse.text = "Response 2";
                StartCoroutine(responseTwoFollowedbySix ());
                break;
        
            case 2:
                Debug.Log("third Option");
                telResponse.text = "Response 3";
                StartCoroutine(responseThreeFollowedbyFourFollowedbySeven ());
                break;
        
            default:
                otherScript.ReturnKeyPressed();
                break;
        }
        showConversation = false;
    }
