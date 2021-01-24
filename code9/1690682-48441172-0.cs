    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.TabControlMain = new System.Windows.Forms.TabControl();
      this.tabControlMain_tp17 = new System.Windows.Forms.TabPage();
      this.tabControlMain_ilMain = new System.Windows.Forms.ImageList(this.components);
      this.TabControlMain.SuspendLayout();
      this.SuspendLayout();
      // 
      // TabControlMain
      // 
      this.TabControlMain.Controls.Add(this.tabControlMain_tp17);
      this.TabControlMain.ImageList = this.tabControlMain_ilMain;
      this.TabControlMain.Location = new System.Drawing.Point(44, 42);
      this.TabControlMain.Size = new System.Drawing.Size(192, 191);
      // 
      // tabControlMain_tp17
      // 
      this.tabControlMain_tp17.ImageIndex = 0;
      this.tabControlMain_tp17.Location = new System.Drawing.Point(4, 23);
      this.tabControlMain_tp17.Text = "tabControlMain_tp17";
      // 
      // tabControlMain_ilMain
      // 
      this.tabControlMain_ilMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("tabControlMain_ilMain.ImageStream")));
      this.tabControlMain_ilMain.TransparentColor = System.Drawing.Color.Transparent;
      this.tabControlMain_ilMain.Images.SetKeyName(0, "");
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 261);
      this.Controls.Add(this.TabControlMain);
      this.TabControlMain.ResumeLayout(false);
      this.ResumeLayout(false);
    
    }
    
    private System.Windows.Forms.TabControl TabControlMain;
    private System.Windows.Forms.TabPage tabControlMain_tp17;
    private System.Windows.Forms.ImageList tabControlMain_ilMain;
