    public static Transform operator +(Transform transform, ManipulationInformation manipulationInformation)
    {
        var type = ApplyManipulation(manipulationInformation, transform.position);
            
        switch (manipulationInformation.ManipulationType)
        {
            case "Scale":
                transform.lossyScale = type;
                break;
            case "Rotate":
                transform.eulerAngles = type;
                break;
            case "Move":
                transform.position = type;
                break;
        }
        return transform;
    }
    private static Vector3 ApplyManipulation(ManipulationInformation manipulationInformation, Vector3 position)
    {
        var offset = manipulationInformation.NumericalSign * ModificationIncrement;
        switch (manipulationInformation.Direction)
        {
            case 'x':
                return new Vector3(
                    position.x + offset,
                    position.y,
                    position.z);
            case 'y':
                return new Vector3(
                    position.x,
                    position.y + offset,
                    position.z);
            case 'z':
                return new Vector3(
                    position.x,
                    position.y,
                    position.z + offset);
        }
        throw new InvalidOperationException("Unknown direction: " + manipulationInformation.Direction);
    }
