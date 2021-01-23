    public partial class Main : Form
    {
      private Kunde _kunde;
   
      public Main(Kunde kunde)
      {
         _kunde = kunde;
      }
      
      public void dialog()
      {
        xmodialog = new FolderBrowserDialog();
        xmodialog.Description = "Find dit XMO Directory:";
        xmodialogresult = xmodialog.ShowDialog();
        if (xmodialogresult == DialogResult.OK)
        {
            dir = xmodialog.SelectedPath;
            _kunde.Dir = dir;
        }
      }
      // rest of your code...
    }
    public class Kunde 
    {
      public string Dir { get; set; }
      public void startxmo()
      {
        string startfile = Dir + "\\xmo.exe";
        Process xmoappli = new Process();
        if (File.Exists(startfile))
        {
            xmoappli.StartInfo.FileName = startfile;
            xmoappli.Start();
        }
        else
        {
            MessageBox.Show("XMO.exe blev ikke fundet på den valgte lokation!");
            File.Delete(dir + "\\xmo.ini");
            dialog();
        }
      }
    }
