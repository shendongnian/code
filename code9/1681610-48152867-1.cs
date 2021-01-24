        public void Configuration_Tab_n_Click_New(int instance)
        {
            #region Variable Declarations
            WpfRadioButton uIUCRadioButton = this.UIOptimalSynTQClientShWindow.UIDesignSurfaceCustom.UIOptimalSynTQClientInCustom2.UIUCRadioButton;
            uIUCRadioButton.SearchProperties.Add(WpfRadioButton.PropertyNames.ControlType, "RadioButton");
            uIUCRadioButton.SearchProperties.Add(WpfRadioButton.PropertyNames.ClassName, "Uia.RadioButton");
            #endregion
            var uIUCRadioButtonList = uIUCRadioButton.FindMatchingControls();
            var clickableButton = uIUCRadioButtonList[instance];
            var point = clickableButton.BoundingRectangle;
            Point relativePoint = new Point(point.X + 10, point.Y + 10);
            Mouse.Click(clickableButton, relativePoint);
        }
        //Run the test
        [TestMethod()]
        public void Common_Configuration_SelectTab_3_New()
        {
            this.UIMap.Configuration_Tab_n_Click_New(3);
        }
