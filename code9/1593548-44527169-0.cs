_tfsDataConnection = new TfsTeamProjectCollection(new Uri(this._tfsLink));
_tfsDataConnection.Authenticate();
The REST SDK is similar, you should use the default constructor.
VssConnection connection = new VssConnection(new Uri(_tfsLink), new VssCredentials());
_vssDataConnection = connection.GetClient<BuildHttpClient>();
