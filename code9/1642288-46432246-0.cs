        partial class ProjectView
    {
        // This should be private
        private System.Windows.Forms.BindingSource bsFeatures;
        public System.Windows.Forms.BindingSource BindingSource
        {
            get { return bsFeatures; }
        }
        public void ShareOnlyWith(FeatureView  fw)
        {
            fw.BindingSource = bsFeatures;
        }
    }
