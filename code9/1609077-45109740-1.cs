    public class Shot : MonoBehaviour
    {
        private const int MagazineSize = 25; // to remove magic number 25 and 26, also to give this number a meaning
        private PlayerSounds playerSounds;
        public int CoolDown = 5;
        public int ReloadCoolDown;
        public int Shots = 0;
        public int TotalShots;
        public int Magazine = 25;
        public int Ammo = 125;
        void Start()
        {
            ReloadCoolDown = 150;
            playerSounds = new PlayerSounds(GetComponents<AudioSource>());
        }
        void Update()
        {
            if (playerTryingToFire())
            {
                tryToShoot();
                playNoAmmoSoundWhenWithoutAmmo();
            }
            else if (playerTryingToReload())
            {
                tryToReloadHalfMagazine();
                playNoAmmoSoundWhenWithoutAmmo();
            }
            tryToReloadEntireMagazine();
            if (CoolDown > 0) CoolDown--;
            if (ReloadCoolDown > 0) ReloadCoolDown--;
        }
        bool playerTryingToFire()
        {
            return Input.GetKey(KeyCode.Space);
        }
        bool playerTryingToReload()
        {
            return Input.GetKeyDown(KeyCode.R);
        }
        void tryToShoot()
        {
            if (playerCanFire())
            {
                TotalShots++;
                playerSounds.PlayerShot();
                CoolDown = 5;
                Magazine--;
            }
        }
        bool playerCanFire()
        {
            return CoolDown == 0 && ReloadCoolDown == 0 && Magazine > 0;
        }
        void playNoAmmoSoundWhenWithoutAmmo()
        {
            if (!hasAmmo())
            {
                playerSounds.PlayerHasNoAmmo();
            }
        }
        void tryToReloadHalfMagazine()
        {
            if (magazineIsNotFull() && hasAmmo())
            {
                int missingBulletCountInMagazine = MagazineSize - Magazine;
                transferAmmoToMagazine(missingBulletCountInMagazine);
                ReloadCoolDown = 80;
                playerSounds.PlayerRealodingHalfMagazine();
            }
        }
        private bool magazineIsNotFull()
        {
            return Magazine < MagazineSize;
        }
        void tryToReloadEntireMagazine()
        {
            if (Magazine == 0 && hasAmmo())
            {
                transferAmmoToMagazine(MagazineSize);
                ReloadCoolDown = 130;
                playerSounds.PlayerReloadingMagazine();
            }
        }
        private void transferAmmoToMagazine(int maximumAmountToFitMagazine)
        {
            int possibleBulletCountToFit = Math.Min(Ammo, maximumAmountToFitMagazine);
            Magazine += possibleBulletCountToFit;
            Ammo -= possibleBulletCountToFit;
        }
        bool hasAmmo()
        {
            return Ammo > 0;
        }
    }
