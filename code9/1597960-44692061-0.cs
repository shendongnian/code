    protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
    {
        base.OnActivityResult(requestCode, resultCode, data);
        if (resultCode == Result.Ok) {
            string stringRetFromResult = data.GetStringExtra("greeting");
            //stringRetFromResult should hold now the value of 'Hello from the Second Activity!'
        }
    }
