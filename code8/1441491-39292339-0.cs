    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Linq;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                string playListTitle = "Playlist";
                string location = "./07%20The%20Punishment.mp3";
                string trackTitle = "The Punishment";
                string album = "Manos Hadjidakis: 15 Vespers";
                int trackNumber = 7;
                int duration = 125840;
                string header = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                   "<playlist xmlns=\"http://xspf.org/ns/0/\" xmlns:vlc=\"http://www.videolan.org/vlc/playlist/ns/0/\" version=\"1\">" +
                   "</playlist>";
                XDocument doc = XDocument.Parse(header);
                XElement playlist = (XElement)doc.FirstNode;
                XNamespace ns = playlist.GetDefaultNamespace();
                XNamespace vlcNS = playlist.GetNamespaceOfPrefix("vlc");
                XElement tracklist = new XElement(ns + "tracklist");
                
                playlist.Add(new object[] {
                    new XElement(ns + "title", playListTitle),
                    tracklist,
                    new XElement(ns + "extension", new object[] {
                        new XAttribute("application", "http://www.videolan.org/vlc/playlist/0"),
                        new XElement(vlcNS + "item",
                           new XAttribute("tid",0)
                        )
                    })
                });
                 
                tracklist.Add(new object[] {
                       new XElement(ns + "track", new object[] {
                           new XElement(ns + "location", location),
                           new XElement(ns + "title", trackTitle),
                           new XElement(ns + "album", album),
                           new XElement(ns + "trackNum", trackNumber),
                           new XElement(ns + "duration", duration)
                       })
                });
     
            }
        }
    }
