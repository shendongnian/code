    void Awake() {
        item1 = GameObject.FindWithTag ("item1").transform;
        item2 = GameObject.FindWithTag ("item2").transform;
        SlotController slotCtrl = GameObject.Find ("Aera Floor").GetComponent<SlotController> ();
    }
    void Update()
    {
    if (Input.GetMouseButtonUp (0)) {
        if (!slotCtrl.item1Placed) {
            item1.localPosition = Vector3.zero;
            rend1.sortingOrder = 1;
            //otherItems.SetActive (false);
        } else  {
            screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);
            rend1.sortingOrder = -1;
            otherItems.SetActive (true);
            //canDrag = false;
        }
        if (slotCtrl.item2Placed) {
            item2.localPosition = Vector3.zero;
            rend2.sortingOrder = 1;
            //otherItems2.SetActive (false);
        } else {
            screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);
            rend2.sortingOrder = -1;
            otherItems2.SetActive (true);
            //slotHolder.SetActive (true);
            //canDrag = false;
        }
    }
    if (slotCtrl.item1Placed && slotCtrl.item2Placed) {
            slotHolder.SetActive (true);
        }
    }
