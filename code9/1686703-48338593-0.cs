    public class MoveScrollRect : ScrollRect, IMoveHandler, IPointerClickHandler
    {
    private const float speedMultiplier = 0.01f;
    public float xSpeed = 0;
    public float ySpeed = 0;
    private float hPos, vPos;
    void IMoveHandler.OnMove(AxisEventData e)
    {
        xSpeed += e.moveVector.x * (Mathf.Abs(xSpeed) + 0.1f);
        ySpeed += e.moveVector.y * (Mathf.Abs(ySpeed) + 0.1f);
    }
    void Update()
    {
        
        ySpeed = Input.GetAxis("VerticalScroller");
        hPos = horizontalNormalizedPosition + xSpeed * speedMultiplier;
        vPos = verticalNormalizedPosition + ySpeed * speedMultiplier;
        xSpeed = Mathf.Lerp(xSpeed, 0, 0.1f);
        ySpeed = Mathf.Lerp(ySpeed, 0, 0.1f);
        if (movementType == MovementType.Clamped)
        {
            hPos = Mathf.Clamp01(hPos);
            vPos = Mathf.Clamp01(vPos);
        }
        normalizedPosition = new Vector2(hPos, vPos);
    }
    public void OnPointerClick(PointerEventData e)
    {
        EventSystem.current.SetSelectedGameObject(gameObject);
    }
    public override void OnBeginDrag(PointerEventData eventData)
    {
        EventSystem.current.SetSelectedGameObject(gameObject);
        base.OnBeginDrag(eventData);
    }
    }
