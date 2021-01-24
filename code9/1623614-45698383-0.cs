    public List<Vector3> points{ get; set; }
    private void Start()
    {
        points = new List<Vector3>(); // initialize the list
        // Add dummy values to test
        points.Add(new Vector3(1, 2, 3));
        points.Add(new Vector3(4, 5, 6));
        points.Add(new Vector3(7, 8, 9));
        printPoints(); // display
        translate(Vector3.one); // translate with (1,1,1)
        printPoints(); // display again
    }
    public void translate(Vector3 vect)
    {
        // Just an old school for loop instead of foreach so you can modify points directly
        for (int i = 0; i < points.Count; i++)
        {
            points[i] += vect;
        }
    }
    public void printPoints()
    {
        foreach (Vector3 v in points)
        {
            Debug.Log(v);
        }
    }
