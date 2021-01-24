    // stores the current state. (You may even use one of the ILPlotCube.Visible flags directly)
    bool m_panelState = false;
    // give the plot cubes unique tags so we can find them later.
    private void ilPanel1_Load(object sender, EventArgs e) {
        ilPanel1.Scene.Add(new ILPlotCube("plotcube1") {
            Plots = {
                Shapes.Circle100, // just some arbitrary content
                new ILLabel("Plot Cube 1")
            },
            // first plot cube starts invisible
            Visible = false
        });
        ilPanel1.Scene.Add(new ILPlotCube("plotcube2") {
            Plots = {
                Shapes.Hemisphere, // just some content
                new ILLabel("Plot Cube 2")
            }
        });
    }
    // a button is used to switch between the plot cubes
    private void button1_Click(object sender, EventArgs e) {
        m_panelState = !m_panelState;
        SetState(); 
    }
    // both plot cubes are made (un)visible depending on the value of the state variable
    private void SetState() {
        ilPanel1.Scene.First<ILPlotCube>("plotcube1").Visible = m_panelState;
        ilPanel1.Scene.First<ILPlotCube>("plotcube2").Visible = !m_panelState;
        ilPanel1.Refresh(); 
    }
