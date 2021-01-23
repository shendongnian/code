private void uncleFoo() {
	enum myNATO { Adam, Bravo, Charlie, Delta } //my enum with NATO codes
	int activeNATO = 0; //int to store selected NATO codes
    //some testing here
	activeNATO |= 1 &lt;&lt; (int)myNATO.Adam;
	activeNATO |= 1 &lt;&lt; (int)myNATO.Bravo;
	activeNATO |= 1 &lt;&lt; (int)myNATO.Charlie;
	Debug.Log(activeNATO);
	Debug.Log("has  Adam? " + (activeNATO & 1 &lt;&lt; (int)myNATO.Adam));
	Debug.Log("has Delta? " + (activeNATO & 1 &lt;&lt; (int)myNATO.Delta));
}
