    void Start()
    {
        _(DoThings("Hello"));
        _(DoAnotherThing(" world!"));
    }
    void _(IEnumerator Method)
    {
        StartCoroutine(Method);
    }
    IEnumerator DoThings(string value)
    {
        yield return new WaitForSeconds(1);
        Debug.Log(value);
    }
    IEnumerator DoAnotherThing(string value)
    {
        yield return new WaitForSeconds(1);
        Debug.Log(value);
    }
