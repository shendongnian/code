        public Instruction DeliveryInstruction()
        {
            try
            {
                int instructionCode = int.Parse(observation.Substring(173,2));
                string instructionData = observation.Substring(175, 10);
                return DeliveryInstructionFactory.Create(instructionCode, instructionData);            }
            catch (Exception ex)
            {
                Log.Error("[ValidationBarcodeResponse] DeliveryInstructions aren't in the correct format", ex);
                return null;
            }
        }
