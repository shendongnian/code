    IEnumerator playAndWaitForAnim(GameObject target, string clipName)
    {
        Animation anim = target.GetComponent<Animation>();
        anim.Play(clipName);
    
        //Wait until Animation is done Playing
        while (anim.IsPlaying(clipName))
        {
            yield return null;
        }
    
        //Done playing. Do something below!
        Debug.Log("Done Playing");
    }
