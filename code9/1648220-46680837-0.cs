    public partial class Form1 : Form
    {
        const int SIZE = 1000;
        int[] eventsArray = new int[SIZE];
        //as per your requirement, you would need these 
        //to display and set items at proper index in the array.
        int _setIndex = 0;
        int _viewIndex = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void btnSet_Click(object sender, EventArgs e)
        {
            //this is where your problem is. Every time the Set btn is clicked,
            //you are creating a new array. Therefore you are only seeing what you added in the 
            //last click. Anything that was added to the array on the prior clicks are lost because
            //you just created a new array with the line below.
            //eventsArray = new int[SIZE];
            //You would need to comment the line above because this is code block is being 
            //executed on every btnSet click. New up this array only once by moving this to global scope.
            //for (int index = 0; index < eventsArray.Length - 1; index++)
            //{
            //    eventsArray[index] = Convert.ToInt32(txtEventName.Text);
            //}
            //Since we have created fields to keep track of _setIndex, all we need to do is:
            if (_setIndex < SIZE)
            {
                eventsArray[_setIndex] = Convert.ToInt32(txtEventName.Text);
                _setIndex++;
            }
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            //this wont be necessary.
            //for (int index = 0; index < eventsArray.Length - 1; index++)
            //{
            //    Debug.WriteLine(eventsArray[index]);
            //    txtName.Text = Convert.ToString(eventsArray[index]);
            //}
            if(eventsArray.Length > _viewIndex)
            {
                txtName.Text = Convert.ToString(eventsArray[_viewIndex]);
                //this is to fulfill the requirement below:
                // Similarly, the first time the user presses “View”, the item found in index 0 
                // of the array is shown to the user; the second time the user presses “View”,
                // the item found in index 1 of the array is shown, etc.
                _viewIndex++;
            }
        }
    }
