    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // assuming your collision.gameObject
            // has the ICoinPicker interface implemented
            ExecuteEvents.Execute<ICoinPicker>(collision.gameObject, score, (a,b)=>a.CoinPickedUp(b));
        }
    }
