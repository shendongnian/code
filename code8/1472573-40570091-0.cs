    public class WholeScreenPointer : MonoBehaviour
    {
        //////////////////////////////// SINGLETON BEGIN  ////////////////////////////////
        private static WholeScreenPointer localInstance;
    
        public static WholeScreenPointer Instance { get { return localInstance; } }
        public EventUnBlocker eventRouter;
    
        private void Awake()
        {
            if (localInstance != null && localInstance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                localInstance = this;
            }
        }
        //////////////////////////////// SINGLETON END  ////////////////////////////////
    
    
        //////////////////////////////// SETTINGS BEGIN  ////////////////////////////////
        public bool simulateUIEvent = true;
        public bool simulateColliderEvent = true;
        public bool simulateCollider2DEvent = true;
    
        public bool hideWholeScreenInTheEditor = false;
        //////////////////////////////// SETTINGS END  ////////////////////////////////
    
    
        private GameObject hiddenCanvas;
    
        private List<GameObject> registeredGameobjects = new List<GameObject>();
    
        //////////////////////////////// USEFUL FUNCTIONS BEGIN  ////////////////////////////////
        public void registerGameObject(GameObject objToRegister)
        {
            if (!isRegistered(objToRegister))
            {
                registeredGameobjects.Add(objToRegister);
            }
        }
    
        public void unRegisterGameObject(GameObject objToRegister)
        {
            if (isRegistered(objToRegister))
            {
                registeredGameobjects.Remove(objToRegister);
            }
        }
    
        public bool isRegistered(GameObject objToRegister)
        {
            return registeredGameobjects.Contains(objToRegister);
        }
    
        public void enablewholeScreenPointer(bool enable)
        {
            hiddenCanvas.SetActive(enable);
        }
        //////////////////////////////// USEFUL FUNCTIONS END  ////////////////////////////////
    
        // Use this for initialization
        private void Start()
        {
            makeAndConfigWholeScreenPinter(hideWholeScreenInTheEditor);
        }
    
        private void makeAndConfigWholeScreenPinter(bool hide = true)
        {
            //Create and Add Canvas Component
            createCanvas(hide);
    
            //Add Rect Transform Component
            //addRectTransform();
    
            //Add Canvas Scaler Component
            addCanvasScaler();
    
            //Add Graphics Raycaster Component
            addGraphicsRaycaster();
    
            //Create Hidden Panel GameObject
            GameObject panel = createHiddenPanel(hide);
    
            //Make the Image to be positioned in the middle of the screen then fix its anchor
            stretchImageAndConfigAnchor(panel);
    
            //Add EventForwarder script
            addEventForwarder(panel);
    
            //Add EventUnBlocker
            addEventRouter(panel);
    
            //Add EventSystem and Input Module
            addEventSystemAndInputModule();
        }
    
        //Creates Hidden GameObject and attaches Canvas component to it
        private void createCanvas(bool hide)
        {
            //Create Canvas GameObject
            hiddenCanvas = new GameObject("___HiddenCanvas");
            if (hide)
            {
                hiddenCanvas.hideFlags = HideFlags.HideAndDontSave;
            }
    
            //Create and Add Canvas Component
            Canvas cnvs = hiddenCanvas.AddComponent<Canvas>();
            cnvs.renderMode = RenderMode.ScreenSpaceOverlay;
            cnvs.pixelPerfect = false;
    
            //Set Cavas sorting order to be above other Canvas sorting order
            cnvs.sortingOrder = 12;
    
            cnvs.targetDisplay = 0;
    
            //Make it child of the GameObject this script is attached to
            hiddenCanvas.transform.SetParent(gameObject.transform);
        }
    
        private void addRectTransform()
        {
            RectTransform rctrfm = hiddenCanvas.AddComponent<RectTransform>();
        }
    
        //Adds CanvasScaler component to the Canvas GameObject 
        private void addCanvasScaler()
        {
            CanvasScaler cvsl = hiddenCanvas.AddComponent<CanvasScaler>();
            cvsl.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            cvsl.referenceResolution = new Vector2(800f, 600f);
            cvsl.matchWidthOrHeight = 0.5f;
            cvsl.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
            cvsl.referencePixelsPerUnit = 100f;
        }
    
        //Adds GraphicRaycaster component to the Canvas GameObject 
        private void addGraphicsRaycaster()
        {
            GraphicRaycaster grcter = hiddenCanvas.AddComponent<GraphicRaycaster>();
            grcter.ignoreReversedGraphics = true;
            grcter.blockingObjects = GraphicRaycaster.BlockingObjects.None;
        }
    
        //Creates Hidden Panel and attaches Image component to it
        private GameObject createHiddenPanel(bool hide)
        {
            //Create Hidden Panel GameObject
            GameObject hiddenPanel = new GameObject("___HiddenPanel");
            if (hide)
            {
                hiddenPanel.hideFlags = HideFlags.HideAndDontSave;
            }
    
            //Add Image Component to the hidden panel
            Image pnlImg = hiddenPanel.AddComponent<Image>();
            pnlImg.sprite = null;
            pnlImg.color = new Color(1, 1, 1, 0); //Invisible
            pnlImg.material = null;
            pnlImg.raycastTarget = true;
    
            //Make it child of HiddenCanvas GameObject
            hiddenPanel.transform.SetParent(hiddenCanvas.transform);
            return hiddenPanel;
        }
    
        //Set Canvas width and height,to matach screen width and height then set anchor points to the corner of canvas.
        private void stretchImageAndConfigAnchor(GameObject panel)
        {
            Image pnlImg = panel.GetComponent<Image>();
    
            //Reset postion to middle of the screen
            pnlImg.rectTransform.anchoredPosition3D = new Vector3(0, 0, 0);
    
            //Stretch the Image so that the whole screen is totally covered
            pnlImg.rectTransform.anchorMin = new Vector2(0, 0);
            pnlImg.rectTransform.anchorMax = new Vector2(1, 1);
            pnlImg.rectTransform.pivot = new Vector2(0.5f, 0.5f);
        }
    
        //Adds EventForwarder script to the Hidden Panel GameObject 
        private void addEventForwarder(GameObject panel)
        {
            EventForwarder evnfwdr = panel.AddComponent<EventForwarder>();
        }
    
        //Adds EventUnBlocker script to the Hidden Panel GameObject 
        private void addEventRouter(GameObject panel)
        {
            EventUnBlocker evtrtr = panel.AddComponent<EventUnBlocker>();
            eventRouter = evtrtr;
        }
    
        //Add EventSystem
        private void addEventSystemAndInputModule()
        {
            //Check if EventSystem exist. If it does not create and add it
            EventSystem eventSys = FindObjectOfType<EventSystem>();
            if (eventSys == null)
            {
                GameObject evObj = new GameObject("EventSystem");
                EventSystem evs = evObj.AddComponent<EventSystem>();
                evs.firstSelectedGameObject = null;
                evs.sendNavigationEvents = true;
                evs.pixelDragThreshold = 5;
                eventSys = evs;
            }
    
            //Check if StandaloneInputModule exist. If it does not create and add it
            StandaloneInputModule sdlIpModl = FindObjectOfType<StandaloneInputModule>();
            if (sdlIpModl == null)
            {
                sdlIpModl = eventSys.gameObject.AddComponent<StandaloneInputModule>();
                sdlIpModl.horizontalAxis = "Horizontal";
                sdlIpModl.verticalAxis = "Vertical";
                sdlIpModl.submitButton = "Submit";
                sdlIpModl.cancelButton = "Cancel";
                sdlIpModl.inputActionsPerSecond = 10f;
                sdlIpModl.repeatDelay = 0.5f;
                sdlIpModl.forceModuleActive = false;
            }
        }
    
        /*
         Forwards Handler Event to every GameObject that implements  IDragHandler, IPointerDownHandler, IPointerUpHandler interface
         */
    
        public void forwardDragEvent(PointerEventData eventData)
        {
            //Route and send the event to UI and Colliders
            for (int i = 0; i < registeredGameobjects.Count; i++)
            {
                ExecuteEvents.Execute<IDragHandler>(registeredGameobjects[i],
                                        eventData,
                                        ExecuteEvents.dragHandler);
            }
    
            //Route and send the event to UI and Colliders
            eventRouter.routeDragEvent(eventData);
        }
    
        public void forwardPointerDownEvent(PointerEventData eventData)
        {
            //Send the event to all subscribed scripts
            for (int i = 0; i < registeredGameobjects.Count; i++)
            {
                ExecuteEvents.Execute<IPointerDownHandler>(registeredGameobjects[i],
                                  eventData,
                                  ExecuteEvents.pointerDownHandler);
            }
    
            //Route and send the event to UI and Colliders
            eventRouter.routePointerDownEvent(eventData);
        }
    
        public void forwardPointerUpEvent(PointerEventData eventData)
        {
            //Send the event to all subscribed scripts
            for (int i = 0; i < registeredGameobjects.Count; i++)
            {
                ExecuteEvents.Execute<IPointerUpHandler>(registeredGameobjects[i],
                        eventData,
                        ExecuteEvents.pointerUpHandler);
            }
    
            //Route and send the event to UI and Colliders
            eventRouter.routePointerUpEvent(eventData);
        }
    }
