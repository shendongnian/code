        /// <include file='doc\ListViewItem.uex' path='docs/doc[@for="ListViewItem.SubItems"]/*' />
        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        [
        SRCategory(SR.CatData),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),        
        SRDescription(SR.ListViewItemSubItemsDescr),
        Editor("System.Windows.Forms.Design.ListViewSubItemCollectionEditor, " + AssemblyRef.SystemDesign,typeof(UITypeEditor)),
        ]
        public ListViewSubItemCollection SubItems {
            get {
                if (SubItemCount == 0) {
                    subItems = new ListViewSubItem[1];
                    subItems[0] = new ListViewSubItem(this, string.Empty);                        
                    SubItemCount = 1;
                }
            
                if (listViewSubItemCollection == null) {
                    listViewSubItemCollection = new ListViewSubItemCollection(this);
                }
                return listViewSubItemCollection;
            }
        }
