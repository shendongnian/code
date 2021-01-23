    public class Effect
    {
    
        public float dps = 2f;
        public float duration = 2f;
        public operatingDelay = 0.1f;
        public bool freezing = false;
    
        MonoBehaviour coroutineMono;
    
        public Effect()
        {
    
            coroutineMono = GameObject.Find("StatsObj").GetComponent<Stats>().monoRef;
            coroutineMono.StartCoroutine("DamageHealRoutine");
        }
    
        IEnumerator DamageHealRoutine()
        {
            int goalCount = (int)(duration / operatingDelay);
            float partialDamage = dps * operatingDelay;
            for (int i = 0; i < goalCount; i++)
            {
                if (dps > 0)
                    stats.TakeDamage(partialDamage);
                else if (dps < 0)
                    stats.GetHeal(partialDamage);
                yield return new WaitForSeconds(operatingDelay);
            }
        }
    }
