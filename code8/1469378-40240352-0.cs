    using Ektron.Custom.SmartForms;
    using System;
    using System.Linq;
    
    public partial class Source_Controls_Alumni_Gallery : System.Web.UI.UserControl
    {
        // Added Property
        private long _containerId = 0;
        public long ContainerID {
            get { return _containerId; }
            set { _containerId = value; }
        }
        /////////
        protected void Page_Load(object sender, EventArgs e)
        {
            // Added inverted conditional to escape method 
            // if the _containerId is invalid.
            if(_containerId <= 0) return;
            ///////////
            var pressPhotoManager = new PressPhotoManager();
    
            // Whichever folder Id... 
            var photos = pressPhotoManager.GetList(75);
    
            if (photos != null && photos.Any())
            {
                uxPhotoGallery.DataSource = photos;
                uxPhotoGallery.DataBind();
            }
        }
    }
