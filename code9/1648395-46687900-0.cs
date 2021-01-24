                AHPModel model; 
                public Weighing_Factors_Pairwise(Form4 frm4)
                {
                    InitializeComponent();
                    this.frm4 = frm4;
                    n = frm4.checkbox.Count;
                    m = frm4.checksys.Count;
                    APModel = new AHPModel(n,m);
                }
