    var generation = new NetworkUtils().GetConnectionGeneration();
    swtich (generation)
    { 
       case NetworkUtils.ConnType.CONN_MY:
       {
          //...
          break;
       }
       case NetworkUtils.ConnType.CONN_WIF:
       {
          //...
          break;
       }
       // othes cases
       default:
         // handle exceptional case
    }
