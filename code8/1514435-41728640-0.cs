    private void writeAllStates()
    {
        AnimatorControllerLayer[] allLayer = controller.layers;
        List<string> stateNames = new List<string>();
        for (int i = 0; i < allLayer.Length; i++)
        {
            ChildAnimatorState[] states = allLayer[i].stateMachine.states;
            for (int j = 0; j < states.Length; j++)
            {
                // you could do additional filtering here. like "would i like to add this state to my list because it has no exit transition" etc
                if (shouldBeInserted(states[i]))
                {
                    // add state to list
                    stateNames.Add(states[j].state.name);
                }
            }
        }
        // now generate a textfile to write all the states
        FileGenerator.createFileForController(controller, stateNames);
    }
