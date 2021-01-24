    {
    private List<GameObject> wheels = new List<GameObject>();
    private float totalwheelpower;
    private List<bool> activewheels = new List<bool>();
    private void Awake()
    {
        int four = 4;
        while (four != 0)
        {
            GameObject wheel = new GameObject();
            bool wheelactive = false;
            activewheels.Add(wheelactive);
            wheels.Add(wheel);
            four--;
        }
    }
    void distributepower()
    {
        float powerperwheel;
        int currentactive=0;
        foreach(bool el in activewheels)
        {
            if (el)
            {
                currentactive++;
            }
        }
        powerperwheel = totalwheelpower / currentactive;
    }
}
