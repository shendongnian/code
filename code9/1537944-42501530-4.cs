    public void UserSelected(bool isTrue)
    {
        animator.SetTrigger(isTrue ? "True" : "False");
        if (currentfacts.IsTrue == isTrue)
        {
            Debug.Log("CORRECT !");
    
        }
        else
        {
            Debug.Log("WRONG !");
    
        }
    
    
        StartCoroutine(TransitionToNextFact());
    }
