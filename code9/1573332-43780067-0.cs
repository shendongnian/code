    IEnumerator PayAdditionalCostAndPlay()
    {       
        if (DiscardCost > 0 && ValidSpell()) 
        {
            Player.ActionCancelled = false;
            Player.targets.Clear();
            Debug.Log("this card has an additional discard cost");
            for (int i = 0; i < DiscardCost; i++) 
            {
                Player.NeedTarget = 21; // a card in hand to discard
    
                while (Player.NeedTarget > 0)
                    yield return new WaitForSeconds (0.1f);
                if (Player.ActionCancelled) {
                    Debug.Log("action cancelled");
                    yield break;
                }
            }
            foreach (GameObject target in Player.targets) //discard
                target.GetComponent<card>().Discard();
        }
    }
