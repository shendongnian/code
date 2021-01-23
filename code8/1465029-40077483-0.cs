    //This bit declares the class.  note that all the stuff after it should come inside the open and closed curly braces, so there's already a syntax error here. 
    class FrameData {
        Dictionary<FrameType, Dictionary<Enums.Direction, int>> frameCount;
    }
    // Public parameterless constructor. This gets called when someone creates an instance of the class, e.g. FrameData myframe = new FrameData()
    public FrameData() {
        // initialize the instance variable frameCount with a new dictionary that takes a FrameType as the key and another dictionary of Enums.Direction and ints as key and value
        frameCount = new Dictionary<FrameType, Dictionary<Enums.Direction, int>>();
    }
    // Public method for adding or replacing a key and its value in the frameCount dictionary
    public void SetFrameCount(FrameType type, Enums.Direction dir, int count) {
        // adds a new one if it didn't already have that key
        if (frameCount.ContainsKey(type) == false) {
            frameCount.Add(type, new Dictionary<Enums.Direction, int>());
        }
        // adds a new key to the inner dictionary if it's not there
        if (frameCount[type].ContainsKey(dir) == false) {
            frameCount[type].Add(dir, count);
        } else {
            // otherwise just replaces what was already there
            frameCount[type][dir] = count;
        }
    }
    // fetches the nested value from the inner dictionary given the type and direction
    public int GetFrameCount(FrameType type, Enums.Direction dir) {
        Dictionary<Enums.Direction, int> dirs = null;
        if (frameCount.TryGetValue(type, out dirs)) {
            int value = 0;
            if (dirs.TryGetValue(dir, out value)) {
                return value;
            } else {
                return 0;
            }
        } else {
            return 0;
        }
    }
