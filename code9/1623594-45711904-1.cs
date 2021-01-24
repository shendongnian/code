    public LineRenderer jumpLine;
    private int numberOfPoint = 50;
    [SerializeField]
    List<Vector3> pointPositions = new List<Vector3>();
    CharacterController chara;
    [SerializeField]
    Transform playerTran;
    [SerializeField]
    float gravity = 3.8f;
    [SerializeField]
    float jumpForce = 50F;
    Vector3 moveVector = Vector3.zero;
    [SerializeField]
    Transform jumpCheck;
    [SerializeField]
    Transform jumpPos;
    [SerializeField]
    Transform jumpHightOne;
    bool movejump;
    Vector3 pZero;
    Vector3 pOne;
    float time;
	// Use this for initialization
	void Start ()
    {
        chara = GetComponent<CharacterController>();
        playerTran = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        jumpLine.positionCount = numberOfPoint;
        jumpLine.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update ()
    {
        chara.Move(moveVector);
        if (chara.isGrounded)
        {
            transform.LookAt(playerTran);
        }
        
        moveVector -= Vector3.up * gravity  * Time.deltaTime;
       
        if (Input.GetKeyUp(KeyCode.J))
        {
            jumpCheck.position = new Vector3(playerTran.position.x, 0, playerTran.position.z);
            float angle = findAngle( playerTran.position.x - transform.position.x , playerTran.position.z - transform.position.z);
            Vector3 _toJumpPos = MakeJumpCricle(playerTran.position , jumpCheck.localScale.x/2, angle);
            Vector3 middlePoint = GetTheMiddlePoints(transform.position, playerTran.position, 0.5f);
            jumpHightOne.position = new Vector3(middlePoint.x, jumpHightOne.position.y, middlePoint.z);
            jumpPos.position = new Vector3(_toJumpPos.x, 0, _toJumpPos.z);
            //moveVector = Vector3.up * jumpForce * Time.deltaTime;
            //movejump = true;
            DrawLinerBezierCurves();
        }
        if (movejump)
        {
            //MoveTowardsTarget(jumpPos.position);
        }
       
    }
    Vector3 GetTheMiddlePoints(Vector3 origin, Vector3 destination, float middlepointfactor)
    {
        return (destination - origin) * middlepointfactor + origin;
            // (destination - origin) * 0.5f; 
    }
    float findAngle(float x, float y)
    {
        float value;
        value = (float)((Mathf.Atan2(x, y) / Mathf.PI) * 180);
        if (value < 0)
        {
            value += 360;
        }
        //Debug.Log(value);
        return value;
    }
    Vector3 MakeJumpCricle( Vector3 center, float radius, float angle)
    {
        Vector3 pos = Vector3.zero;
        pos.x = center.x - radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        pos.y = 0;
        pos.z = center.z - radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        return pos;
    }
    void MoveTowardsTarget(Vector3 targetPostios)
    {
        var offset = targetPostios - transform.position;
        if (offset.magnitude > .1f)
        {
            offset = offset.normalized * 15;
            chara.Move(offset * Time.deltaTime);
        }
        else
        {
            movejump = false;
        }
    }
    // line Bezier Curves
    Vector3 CalculateBezierCurvesPoints(float t , Vector3 p0, Vector3 p1 )
    {
        return p0 + t * (p1 - p0);
            // P = P0 + t(P1 – P0)  ,  0 < t < 1
    }
    // line Bezier Curves
    Vector3 CalculateBezierCurvesPoints(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        
        float u = 1 - t;
        float uu = u * u;
        float tt = t * t;
        Vector3 p = uu * p0;
        p = p + 2 * u * t * p1;
        p = p + tt * p2;
        return p;
        //P = (1-t)^2 P0 + 2 (1-t) t P1 + t^2 P2 , 0 < t < 1
        //     uu              u          tt
        //     uu   * p0  + 2 * u  * t * p1  + tt * p2  
    }
    void DrawLinerBezierCurves()
    {
        if (pointPositions.Count > 0)
        {
            pointPositions.Clear();
            jumpLine.positionCount = 0;
            jumpLine.positionCount = numberOfPoint;
        }
        for (int i = 1; i < numberOfPoint + 1; i++)
        {
            float t = i / (float) numberOfPoint;
            if (!jumpLine.gameObject.activeInHierarchy)
            {
                jumpLine.gameObject.SetActive(true);
            }
            pointPositions.Add(CalculateBezierCurvesPoints(t, transform.position,jumpHightOne.position, jumpPos.position));
            jumpLine.SetPosition(i - 1, pointPositions[i - 1]);
        }
        
    }
