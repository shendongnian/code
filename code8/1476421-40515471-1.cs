        //Try this.
        using System;
        using WMPLib;
        using System.IO;
        
        namespace _myNamespace
        {
          public partial class Form1:Form
          {
             //to use 'WindowsMediaPlayer' you need to import WMPLib
             //add a reference "Windows Media Player" from the COM section of vstudio reference manager.
             WindowsMediaPlayer player;
             //constructor
             public Form1
             {
               InitializeComponent();
               PopulateListBox("folder");
               player = new WindowsMediaPlayer();
             }
      
            private void PopulateListBox(string folder)
            { 
               string[] files = Directory.GetFiles(folder);
               foreach(string file in files)
                  listbox1.Items.Add(file);
            }
            
            private void btnPlay_Click(object sender, EventArgs e)
            {
               string file = listbox1.SelectedItem as string;
               if(!string.IsNullOrWhiteSpace(file))
               {
                  player.URL = file;
                  player.controls.play();
               }
             }
          }
       }
