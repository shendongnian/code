    if (Input.GetMouseButton (0) && scoreTrack.sprayBottles > 0) {
            if(!sprayEffect.GetComponent<ParticleSystem> ().isPlaying){ 
                sprayEffect.GetComponent<ParticleSystem> ().Play ();
                sprayEffect.GetComponent<ParticleSystem> ().enableEmission=true;
            }
    }
    else if (!Input.GetMouseButton (0)) {
            if(sprayEffect.GetComponent<ParticleSystem> ().isPlaying){
                sprayEffect.GetComponent<ParticleSystem>().Stop();
                sprayEffect.GetComponent<ParticleSystem> ().enableEmission=false;
            }
    
    }
