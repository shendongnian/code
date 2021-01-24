    private Image joystickBackgroundImage;
    private Image joystickImage;
    public Vector3 InputDirection { set; get; }
    private void Start()
    {
        joystickBackgroundImage = GetComponent<Image>();
        joystickImage = transform.GetChild(0).GetComponent<Image>();
        InputDirection = Vector3.zero;
    }
    public virtual void OnDrag(PointerEventData Ped)
    {
        Vector2 pos = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBackgroundImage.rectTransform, Ped.position, Ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / joystickBackgroundImage.rectTransform.sizeDelta.x);
            pos.y = (pos.y / joystickBackgroundImage.rectTransform.sizeDelta.y);
            float x = (joystickBackgroundImage.rectTransform.pivot.x == 1f) ? pos.x * 2 + 1 : pos.x * 2 - 1;
            float y = (joystickBackgroundImage.rectTransform.pivot.y == 1f) ? pos.y * 2 + 1 : pos.y * 2 - 1;
            InputDirection = new Vector3(x, 0, y);
            InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;
             
            joystickImage.rectTransform.anchoredPosition = new Vector3(InputDirection.x * (joystickBackgroundImage.rectTransform.sizeDelta.x / 3), InputDirection.z * (joystickBackgroundImage.rectTransform.sizeDelta.y/3));
        }
    }
    public virtual void OnPointerDown(PointerEventData Ped)
    {
        OnDrag(Ped);
    }
    public virtual void OnPointerUp(PointerEventData Ped)
    {
        InputDirection = Vector3.zero;
        joystickImage.rectTransform.anchoredPosition = Vector3.zero;
    }
