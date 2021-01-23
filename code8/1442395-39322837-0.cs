    public class dynamicmovement : MonoBehaviour
    {
    
        public GameObject cubePrefab;
        public Slider cubeSlider;
        public Button instantiateButton;
        public Button instantiateButton2;
    
        public Slider cubeSlider2;
    
    
        public float speed = 0f;
        public float pos = 0f;
        public GameObject mcamera;
        Vector3 cposition;
    
        private Transform currentObjectToDrag = null;
    
        // Use this for initialization
        void Start()
        {
            //Set Slider Values
            cubeSlider.minValue = 0f;
            cubeSlider.maxValue = 360f;
            cubeSlider.value = 0f;
    
            cubeSlider2.minValue = 0f;
            cubeSlider2.maxValue = 360f;
            cubeSlider2.value = 0f;
    
    
        }
    
        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 1000.0f))
                {
                    GameObject objHit = hit.collider.gameObject;
                    Debug.Log("We Clicked on : " + objHit.name);
    
                    //Check if this is cube
                    if (objHit.CompareTag("Cube"))
                    {
                        Debug.Log("Cube selected. You can now drag the Cube with the Slider!");
                        //Change the current GameObject to drag
                        currentObjectToDrag = objHit.transform;
                    }
                }
            }
        }
    
        public void instantiateCube()
        {
            //Instantiate(cubePrefab, new Vector3(0, 0, 0), Quaternion.identity);
    
    
            cposition = new Vector3(mcamera.transform.position.x + 80, mcamera.transform.position.y - 2, mcamera.transform.position.z + 10);
    
            cubePrefab.transform.position = cposition;
            //mcamera.transform.position = new Vector3(+10, +10, +10);
    
    
            //transform.position = new Vector3(351, -36, 60);
            Instantiate(cubePrefab, cubePrefab.transform.position, transform.rotation);
    
    
    
    
    
    
            //Instantiate(cubePrefab, new Vector3(519f, -41f, 170f), Quaternion.identity);
        }
    
        public void rotatess(float newspeed)
        {
            speed = newspeed;
    
        }
    
        public void positions(float newpos)
        {
            pos = newpos;
        }
    
        //Called when Instantiate Button is clicked
        void instantiateButtonCallBack()
        {
            Debug.Log("Instantiate Button Clicked!");
            instantiateCube();
        }
    
        //Called when Slider value changes
        void sliderCallBack(float value)
        {
            Debug.Log("Slider Value Moved : " + value);
    
            //Move the Selected GameObject in the Z axis with value from Slider
            if (currentObjectToDrag != null)
            {
                // currentObjectToDrag.position = new Vector3(519f, -41, value);
                currentObjectToDrag.eulerAngles = new Vector3(0, value, 0);
                Debug.Log("Position changed!");
            }
        }
    
        void sliderCallBack2(float value)
        {
            Debug.Log("Slider Value Moved : " + value);
    
            //Move the Selected GameObject in the Z axis with value from Slider
            if (currentObjectToDrag != null)
            {
                // currentObjectToDrag.position = new Vector3(519f, -41, value);
                currentObjectToDrag.position = new Vector3(0, value, 0);
                Debug.Log("Position changed!");
            }
        }
    
        //Subscribe to Button and Slider events
        void OnEnable()
        {
            instantiateButton.onClick.AddListener(instantiateButtonCallBack);
            cubeSlider.onValueChanged.AddListener(delegate { sliderCallBack(cubeSlider.value); });
            cubeSlider2.onValueChanged.AddListener(delegate { sliderCallBack2(cubeSlider2.value); });
        }
    
        //Un-Subscribe to Button and Slider events
        void OnDisable()
        {
            instantiateButton.onClick.RemoveListener(instantiateButtonCallBack);
            cubeSlider.onValueChanged.RemoveListener(delegate { sliderCallBack(cubeSlider.value); });
            cubeSlider2.onValueChanged.RemoveListener(delegate { sliderCallBack2(cubeSlider2.value); });
        }
    }
