    public void NiceBowlingEffects(List<string> Effects)
    {
        StartCoroutine(Animate(Effects));
    }
    private IEnumerator Animate(Effects)
    {
        foreach (var Effect in Effects)
        {
            NBtext.text = Effect;
            print(Effect);
            animator.SetTrigger("SlideText");
            yield return new WaitForSeconds(.75f); //animation is .7 seconds
        }
    }
