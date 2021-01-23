    class Aplication : Android.App.Activity,
        Android.Support.V4.AppActivityCompat.IOnRequestPermissionsResultCallback {
        public override async void OnRequestPermissionsResult(
            int requestCode,
            string[] permissions,
            Android.Content.PM.Permission[] grantResults
        ) {
        }
    }
