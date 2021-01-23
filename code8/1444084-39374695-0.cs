    private bool? projEcho;
    public bool ProjectEcho
        { get
            {
                if (!projEcho.HasValue)
                    projEcho = isProjectEcho();
                return projEcho.Value; 
            }
        }
