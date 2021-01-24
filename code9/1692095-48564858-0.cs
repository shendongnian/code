    public void ToggleChangeButtonPannel(Button button)
    {
        ActionText.text = Description;
        CurrentKeyText.text = Name;
        if (Panel.enabled)
        {
            Panel.enabled = false;
        }
        else
        {
            Panel.enabled = true;
            StartCoroutine(KeyRoutine());
        }
        EventSystem.current.SetSelectedGameObject(null);
    }
    IEnumerator KeyRoutine()
    {
        while (!Panel.enabled || !Input.anyKeyDown)
        {
            yield return null;
        }
        try
        {
            var newKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), Input.inputString.ToUpper());
            if (Shortcuts.TryChangeKeyCode(Key, newKey))
            {
                RenameButtons(newKey);
                Key = newKey;
                Panel.enabled = false;
            }
            else
            {
                 StartCoroutine(RemoveAfterSeconds(3, Panel));
            }
        }
        catch
        {
            StartCoroutine(RemoveAfterSeconds(3, Panel));
        }
    }
