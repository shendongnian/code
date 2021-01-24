        static bool Bonus(GameObject gameObject, int BONGain)
        {
            SomeOther soc = gameObject.GetComponent<SomeOther>();
            if (soc != null)
            {
                soc.value += BONGain;
                return true;
            }
            return false;
        }
