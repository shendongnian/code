    using System.Windows.Forms;
    using Autodesk.AutoCAD.Runtime;
    using Autodesk.AutoCAD.Windows;
    namespace AMU.AutoCAD.BlockTool
    {
      public class MyPalette : IExtensionApplication
      {
      private PaletteSet palette;
      private Control paletteControl;
      public void Initialize()
      {
        //This is called when AutoCAD loads your assembly
        this.palette = new PaletteSet("Name")
        {
          TitleBarLocation = PaletteSetTitleBarLocation.Left,
          Style = PaletteSetStyles.Snappable //Your Styles
        };
        this.paletteControl = new Control(); //Instance of your Control that will be visible in AutoCAD
        this.palette.Add("HEADER", this.paletteControl);
        this.palette.Visible = true;
      }
      public void Terminate()
      {
        //cleanup
        this.palette.Dispose();
        this.paletteControl.Dispose();
      }
    }
    }
