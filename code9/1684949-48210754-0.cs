    public static class WindowsFormsExtensions
    {
    	public static void DisableRoundedEdges(this ToolStripRenderer renderer)
    	{
    		var professionalRenderer = renderer as ToolStripProfessionalRenderer;
    		if (professionalRenderer != null)
    			professionalRenderer.RoundedEdges = false;
    	}
    }
