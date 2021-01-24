     private void button1_Click(object sender, RoutedEventArgs e)
        {
            string folderName = @"E:\PPTFolder\";
            AddSlides(folderName);            
        }
                
        private void AddSlides(string folderName)
        {            
            string[] filePaths = Directory.GetFiles(folderName, "*.pptx", SearchOption.TopDirectoryOnly);
            Microsoft.Office.Core.MsoTriState oFalse = Microsoft.Office.Core.MsoTriState.msoFalse;
            Microsoft.Office.Core.MsoTriState oTrue = Microsoft.Office.Core.MsoTriState.msoTrue;
           
            PowerPoint.Application oApp = new PowerPoint.Application();
            oApp.Visible = oTrue;
            oApp.WindowState = PowerPoint.PpWindowState.ppWindowNormal;
            PowerPoint.Presentation oPres;
            PowerPoint.Slide oSlide=new PowerPoint.Slide();
            for (int i = 0; i < filePaths.Length; i++)
            {
                oPres = oApp.Presentations.Open(filePaths[i], ReadOnly: oFalse);                
                oSlide = oPres.Slides.Add(oPres.Slides.Count + 1, PowerPoint.PpSlideLayout.ppLayoutTitleOnly);
                oSlide.Shapes[1].TextFrame.TextRange.Text = "Final Test";
                oSlide.Shapes[1].TextFrame.TextRange.Font.Name = "Comic Sans MS";
                oSlide.Shapes[1].TextFrame.TextRange.Font.Size = 48;
                oPres.Save();
                oPres.Close();
            }
            oSlide = null;
            oPres = null;
            oApp.Quit();
            oApp = null;
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
