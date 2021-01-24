    class PlayerSounds
        {
            private const int PlayerShootingSound = 0;
            private const int PlayerReloadingMagazineSound = 1;
            private const int PlayerReloadingHalfOfMagazineSound = 2;
            private const int PlayerHasNoAmmoSound = 3;
            private AudioSource[] audio;
            public PlayerSounds(AudioSource[] audio)
            {
                if (audio == null)
                    throw new ArgumentNullException(nameof(audio));
                this.audio = audio;
            }
            public void PlayerShot()
            {
                audio[PlayerShootingSound].Play();
            }
            public void PlayerReloadingMagazine()
            {
                audio[PlayerReloadingMagazineSound].Play();
            }
            public void PlayerRealodingHalfMagazine()
            {
                audio[PlayerReloadingHalfOfMagazineSound].Play();
            }
            public void PlayerHasNoAmmo()
            {
                audio[PlayerHasNoAmmoSound].Play();
            }
        }
