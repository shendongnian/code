    Class LockingWithAwait
	Public Sub Test()
		DoSomething()
	End Sub
	Private Sub doSomething()
		Await Task.Run(Function() PlayTheMusicWithLock())
		CallSubMethodHere()
	End Sub
	Private Sub PlayTheMusicWithLock()
		My.Computer.Audio.Play(My.Resources.Second, AudioPlayMode.WaitToComplete)
	End Sub
	Private Sub CallSubMethodHere()
		Console.WriteLine("Hello world.")
	End Sub
    End Class
