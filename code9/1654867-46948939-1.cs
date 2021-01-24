    public class CoolerSystem
    {
        private bool[] _coolerFanIsOn = new Boolean[5];
        public bool this[int index]
        {
            get => _coolerFanIsOn[index];
            set => _coolerFanIsOn[index] = value;
        }
    }
