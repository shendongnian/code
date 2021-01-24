    public class ExampleClass
    {
        private int section { get; set; }
        public Visibility Visibilityicuc { get; set; } //presume first section
        public Visibility Visibilityj1939 { get; set; } //presume second section
        public Visibility Visibilitypcode { get; set; } //presume third section
        public Visibility Visibilitysgdd { get; set; } //presume fourth section
        public DelegateCommand NextButtonDelegateCommand { get; set; }
        public ExampleClass()
        {
            NextButtonDelegateCommand = new DelegateCommand(Next);
            section = 1; //indicates in first section
        }
        private void SetSectionVisibility(int currSection)
        {
            if (currSection == 1) // if first section
            {
                Visibilityicuc = Visibility.Visible; //section 1
                Visibilityj1939 = Visibility.Hidden;
                Visibilitypcode = Visibility.Hidden;
                Visibilitysgdd = Visibility.Hidden;
            }
            else if (currSection == 2)
            {
                Visibilityicuc = Visibility.Hidden;
                Visibilityj1939 = Visibility.Visible; //section 2
                Visibilitypcode = Visibility.Hidden;
                Visibilitysgdd = Visibility.Hidden;
            }
            else if (currSection == 3)
            {
                Visibilityicuc = Visibility.Hidden;
                Visibilityj1939 = Visibility.Hidden;
                Visibilitypcode = Visibility.Visible; //section 3
                Visibilitysgdd = Visibility.Hidden;
            }
            else if (section == 4)
            {
                Visibilityicuc = Visibility.Hidden;
                Visibilityj1939 = Visibility.Hidden;
                Visibilitypcode = Visibility.Hidden;
                Visibilitysgdd = Visibility.Visible; //section 4
            }
        }
        private void Next()
        {
            if (section == 1)
                SetSectionVisibility(2); //move to next section
            else if (section == 2)
                SetSectionVisibility(3);
            else if (section == 3)
                SetSectionVisibility(4);
            //else if (section == 4)
                //end! special event? unsure
        }
    }
