        public class static UtenteMenuActions {
              private static int _currentTicketNumber = 0; 
              public static void Assign(Utente utente) {
                   //assign to utente 
                   _currentTicketNumber ++; 
              }
              public static void AssignAllUtentes(List<Utente> utenteList>) {
                    foreach (Utente utente : utenteList) {
                           Assign(utente);
                    }
              }
        }
