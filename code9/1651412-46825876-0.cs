    attempt = 0;
    for (int counter = 0; counter < 8; counter++)
    {
        if (attempt < totalitems)
        {
            Tasklist<output>.Add(Task.Run(() =>
            {
                int tmpAttempt = attempt;
                return someasynctask(inputList[tmpAttempt]);
            }));
        }
        else
        {
            break;
        }
        attempt++;
    }
    await Task.WhenAll(Tasklist).ConfigureAwait(false);
