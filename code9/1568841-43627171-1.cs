    public class Test : MonoBehaviour
    {
        private void Start()
        {
            List<Robot> robotsList = new List<Robot>();
            List<string> namesList = new List<string>();
            namesList.Add("yellow");
            namesList.Add("green");
            namesList.Add("red");
            PopulateRobotsList();
            DisplayRobotsListContent();
        }
        private void PopulateRobotsList()
        {
            for(int id = 0; id < 100; id++)
            {
                string robotName = namesList[Random.Range(0, namesList.Count)];
                robotsList.Add(new Robot(robotName, id));
                //Debug.Log(robotsList[robotsList.Count - 1]);
            }
        }
        private void DisplayRobotsListContent()
        {
            int[] robotsNamesCount = new int[namesList.Count];
            for (int i = 0; i < robotsList.Count; i++)
            {
                robotsNamesCount[namesList.IndexOf(robotsList[i].name)] += 1;
            }
            for (int i = 0; i < namesList.Count; i++)
            {
                Debug.Log("Robot(s) named \"" + namesList[i] + "\" : " + robotsNamesCount[i]);
            }
        }
    }
    public class Robot
    {
        public string name;
        public int id;
        public Robot(string name, int id)
        {
            this.name = name;
            this.id = id;
        }
    }
