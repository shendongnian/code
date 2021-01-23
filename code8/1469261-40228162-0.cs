    bool TestFinished;
    IEnumerator RunTest() {
        for (int i = 0;  i < numberOfAvatars; i++) {
            TestFinished = false;
            StartTest(avatars[i]); // This is not really relevent to the question
            
            //Wait until the FinishTest event is finished before continuing the loop
            while (!TestFinished) yield return null;
        }
    }
    private void FinishTest()
    {
        testsResults[testNumber] = new TestResult(avatarsName, holdingObject); 
        testsResults[testNumber].setTimeUntilAvatarGotShot(string.Format("{0:F2}",timer);
        TestFinished = true;
    }
