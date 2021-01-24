    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // assuming your collision.gameObject
            // has the ICoinPicker interface implemented
            ExecuteEvents.Execute<ICoinPickedHandler>(collision.gameObject, new CoinPickedEventData(score), (a,b)=>a.OnCoinPickedUp(b));
        }
    }
