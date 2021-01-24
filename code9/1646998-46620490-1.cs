    [DefaultValue("")]
    [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design")]
    [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design",
        typeof(System.Drawing.Design.UITypeEditor))]
    public string DataColumn{ get; set; }
