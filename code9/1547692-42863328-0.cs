    using Microsoft.Office.Tools.Ribbon;
    using Excel = Microsoft.Office.Interop.Excel;
    using Controllers;
    
    namespace Johnson
    {
        public partial class JohnsonRibbon
        {
            private void JohnsonRibbon_Load(object sender, RibbonUIEventArgs e)
            {
    
            }
    
            private void OnInitalButtonClick(object sender, RibbonControlEventArgs e)
            {
                string Prompt = "Select two data columns (X, Freq) for analysis";
                string Title = "Select Histogram";
                var range = Globals.ThisAddIn.Application.InputBox(Prompt: Prompt, Title: Title, Type: 8);
                if (range is Excel.Range)
                {
                    new InitialController(new Usecases.InitialUsecase()).Execute();
                }
            }
        }
    }
