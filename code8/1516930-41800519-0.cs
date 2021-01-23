    public class InputHandler, MonoBehaviour, IPointerUpHandler
    {
        IEnumerator coroutine = null;
        public void LaserAttack(){
            isAttacking = true;
            this.coroutine = AttackStillCoroutine ()
            StartCoroutine (this.coroutine);
           // More code
        }
        public void OnPointerUp(PointerEventData eventData)
        {
             if(this.isAttacking == true && this.coroutine != null ){
                 StopCoroutine(this.coroutine);
                 this.coroutine = null;
             }
        }
    }
