    namespace Bouncinglabels
    {
    using System.Windows.Forms;
    class LabelBouncer
    {
        public Label MyLabel;
        public bool GoingForward = true;
        public void Move()
        {
            if (MyLabel != null) 
            {
                if (GoingForward)
                {
                    MyLabel.Left += 5;
                }
                else
                {
                   MyLabel.Left -= 5;
                   if (MyLabel.Left <= 0)
                   {
                       GoingForward = true;
                   }
                }
                if (MyLabel.Right >= MyLabel.Parent.Width)
                {
                    GoingForward = false;
                }
            }
        }
      }
    }
