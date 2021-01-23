    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "OnTop Detector")
        {
            Debug.Log("On Top of Platform");
            GameObject findGo = GameObject.Find("ThirdPersonController");
            GameObject findGo1 = GameObject.Find("Elevator");
            findGo.transform.parent = findGo1.transform;
            target = GameObject.Find("Elevator");
            Animation anim = target.GetComponent<Animation>();
            anim.Play("Up");
            //Wait until Up is done Playing the play down
            while (anim.IsPlaying("Up"))
            {
                yield return null;
            }
            //Now Play Down
            anim.Play("Down");
        }
    }
