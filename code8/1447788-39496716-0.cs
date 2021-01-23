    // I got a form with a virtual listview and a icon list
    // there may be some mistakes I had to edit it together
    public class DirContent // directory content like one file or one folder
    {
        public string Name;
        public string Path;
        public string Modyfied;
        public string Extention;
        public string Size;
    }
    public class DirectoryContent //this contains a list with mulyble files and folders and the previous folder and selected folder
    {
        public List<DirContent> dirContent = new List<DirContent>();
        public string previousDirectory;
        public string selectedDirectory;
    }
    public partial class Form1 : Form
    {
        static Dictionary<string, int> IconDictornary = new Dictionary<string, int>(); //this is a Dictionary to keep track of the loaded files;
        static DirContent directoryContent = // file to load the icon for 
        public Form1()
        {
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Icon icon = Icon.ExtractAssociatedIcon(@"path/to/file/file.png");
            icons.Images.Add("empty", icon); // add empty file icon to imageList of form; (index 1) (index 0 = folder icon) i set that in imagelist propperites
        }
        public void getFileIcon() // I had a list view and had to cut out some things to show only the usefull stuf
        {
            // I had a virtual list view it much better for rendering. The system32 folder contains allot of files. so this is a handy thing 
            int index;
            if (itemIndex == 0) // i checked if the index of te listview item that has to render == 0;
            {
                ListViewItem parrentItem = new ListViewItem("", 0);
                parrentItem.SubItems.Add("..");
                parrentItem.SubItems.Add("");
                parrentItem.SubItems.Add("");
                listview[itemIndex].Item = parrentItem;
                // set on index 0 of list view a .. for previous folder
            }
            else
            {
                if (IconDictornary.ContainsKey(directoryContent[ItemIndex].Extention)) // If the icon already loaded in to  IconDictornary get the key that wil be presented by the index of the icon in the icon list;
                {
                    index = IconDictornary[directoryContent[ItemIndex].Extention];
                }
                else
                {
                    index = GetIconIndexFromIcon(directoryContent[ItemIndex].Extention); // get File/folder icon
                }
                ListViewItem lvi = new ListViewItem("", index); // image index of icon in icon list 
                lvi.SubItems.Add(directoryContent[ItemIndex].Name);
                lvi.SubItems.Add(directoryContent[ItemIndex].Modyfied);
                lvi.SubItems.Add(directoryContent[ItemIndex].Size);
                listview[itemIndex].Item = lvi;
                // set details for sub items and show it to list view
            }
        }
        private int GetIconIndexGetIcon(string extention)
        {
            Icon icon;
            int index = 0;
            try
            {
                if (extention == ".folder") // i check if the file extention  = .folder if yes index = 0; iconlist[0] == folder. as I sayd above
                {
                    index = 0;
                }
                else
                {
                    icon = Icons.IconFromExtension(extention, Icons.SystemIconSize.Large); // get icon by extention
                    icons.Images.Add(extention, icon); // add to icon list with key, icon 
                    index = icons.Images.IndexOfKey(extention);
                    IconDictornary.Add(extention, index); // set loaded file to IconDictornary by extention and index from the icon list
                }
            }
            catch
            {
                index = 1;
            }
            return index; // return index where to find icon
        }
    }
