    public IEnumerator LoadAsynchron(string myMain, Button bttn)
    {
        operation = SceneManager.LoadSceneAsync(myMain);
        operation.allowSceneActivation = false;
        while (operation.progress < 0.9f)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            txx.text = progress * 100f + " %";
            if (progress * 100f == 100f)
            {
                bttn.interactable = true;
            }
            yield return null;
        }
        if (!bttn.interactable)
            bttn.interactable = true;
    }
