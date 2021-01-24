	*********************************************************************
	public class ChangeSize : MonoBehaviour 
	{
		float[] numbers;
		HashSet<float> numberCheck;   // hashset
	
		int MyIndex;
		public int Range;
		int trialCount = 0;
		// Use this for initialization
		void Start () { //************************************Start
			numbers = new float[] { 1.0f,2.0f,3.0f,1.0f,2.0f,3.0f };
		}
		// Update is called once per frame
		void Update()
		{
			changeSizeObj();
		}
		//**************************************************Functions
		void changeSizeObj() {
			if (Input.GetKeyDown("a"))
			{
				transformSize();
			}
		}
		void transformSize()
		{
			float num = numbers[trialCount];
			
			if (numberCheck.Contains(num))  // check for duplicates
				print(num);
			else
				numberCheck.Add(num);
			transform.localScale = new Vector3(num, num, num);
			trialCount += 1;
		}
	}
	
