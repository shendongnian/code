    public float rotationSpeed = 0.01f ;
	private Transform child;
	private float initialYRotation;
	private bool textChanged = false;
	private void Awake()
	{
		child = transform.GetChild(0);
		initialYRotation = child.rotation.eulerAngles.y ;
	}
	private void Update()
	{
		Vector3 fromRotation = child.eulerAngles ;
		Vector3 toRotation = new Vector3( 0, 360, 0 ) ;
		Vector3 rotation = Vector3.Lerp( fromRotation, toRotation, Time.deltaTime * rotationSpeed );
		child.eulerAngles = rotation;
		if( !textChanged && Mathf.Abs( rotation.y - initialYRotation ) > 90 )
		{
			transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "Success";
			textChanged = true ;
		}
	}
