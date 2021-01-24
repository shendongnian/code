        //set the control's initial location
        const int HEADERTEXTLOCATIONX = 0;
        const int HEADERTEXTLOCATIONY = 0;
        //set the control's offset value
        const int OFFSETX = 30;
        const int OFFSETY = 20;
        List<Label> headerTextList = new List<Label>();
        private void creatSubControls(int controlsCount)
        {
            for (int item = 0; item < controlsCount; item++)
            {
                guiInit(item);
            }
        }
        private void guiInit(int iControl)
        {
            Label headerText = new Label();
            int offsetX = iControl * OFFSETX;
            int offsetY = iControl * OFFSETY;
            //Header Text
            headerText.AutoSize = true;
            headerText.BackColor = System.Drawing.Color.DarkSlateBlue;
            headerText.Font = new System.Drawing.Font("Roboto Lt", 22F);
            headerText.ForeColor = System.Drawing.SystemColors.ButtonFace;
            headerText.Location = new System.Drawing.Point(HEADERTEXTLOCATIONX + offsetX, HEADERTEXTLOCATIONY + offsetY);
            headerText.Name = "headerText";
            headerText.Size = new System.Drawing.Size(178, 29);
            headerText.TabIndex = 0;
            headerText.Text = "Server Manager" + (iControl + 1).ToString();
            Controls.Add(headerText);
        }
