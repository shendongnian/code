    public void OnDrop(PointerEventData eventData)
    {
    GameObject dropedItem = eventData.pointerDrag.GetComponent<GameObject>();
    
    if (isEmpty) // you have space for this object
    {
      
      dropedItem.transform.SetParent(this.transform);
      dropedItem.transform.position = //set to any position you need
      dropedItem.GetComponent<CanvasGroup>().blocksRaycasts = true; //so you can pick this item again
    }
    else
    {
      //return it to old position and to old parent
    }
    }
