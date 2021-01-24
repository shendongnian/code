    void OnTriggerEnter(Collider collider)
    {
        GateDescription gateType = collider.GetComponent<GateDescription>();
    
        if (gateType != null)
        {
            switch (gateType.gateType)
            {
                case GateType.StoneGate:
                    break;
    
                case GateType.WoodenGate:
                    break;
    
                case GateType.MetalGate:
                    break;
            }
        }
    }
