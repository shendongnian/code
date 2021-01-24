    public void Update()
    {
            if (inInteractRange && Input.GetKeyDown(KeyCode.E))
            {
                DialogueSystemManager.Instance.StartDialogueForNpc(interactableNPCName);
            }
    }
    private void OnTriggerEnter(Collider col)
    {
       inInteractRange = true;
    }
    private void OnTriggerExit(Collider col)
    {
       inInteractRange = false;
       DialogueSystemManager.Instance.CloseDialogueWindow();
    }
