        private Mfrc522 mfrc = new Mfrc522();
        public static bool IsGpioInitialized = false;
        public async Task ReadNFCAsync()
        {
            if (!IsGpioInitialized)
            {
                await mfrc.InitIO();
                IsGpioInitialized = true;
            }
        }
