    public class LabelClickable: Label
    {
        public LabelClickable()
        {
            TapGestureRecognizer singleTap = new TapGestureRecognizer()
            {
                NumberOfTapsRequired = 1
            };
            TapGestureRecognizer doubleTap = new TapGestureRecognizer()
            {
                NumberOfTapsRequired = 2
            };
            this.GestureRecognizers.Add(singleTap);
            this.GestureRecognizers.Add(doubleTap);
            singleTap.Tapped += Label_Clicked;
            doubleTap.Tapped += Label_Clicked;
        }
        private static int clickCount;
        private void Label_Clicked(object sender, EventArgs e)
        {
            if (clickCount < 1)
            {
                TimeSpan tt = new TimeSpan(0, 0, 0, 0, 250);
                Device.StartTimer(tt, ClickHandle);
            }
            clickCount++;
        }
        bool ClickHandle()
        {
            if (clickCount > 1)
            {
                Minus1();
            }
            else
            {
                Plus1();
            }
            clickCount = 0;
            return false;
        }
        private void Minus1()
        {
            int value = Convert.ToInt16(Text) - 1;
            if (value < 0)
                value = 0;
            Text = value.ToString();
        }
        private void Plus1()
        {
            Text = (Convert.ToInt16(Text) + 1).ToString();
        }
    }
