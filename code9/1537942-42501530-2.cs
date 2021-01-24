    public void UserSelected(bool isTrue)
    {
        animator.SetTrigger(isTrue.ToString());
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
