    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
    
    
    public class GlobalControl2 : MonoBehaviour
    {
    private static GlobalControl2 instance = null;
    
    private string PersistentPlayerName;
    private string PersistentTeamName;
    
    private Text PlayerName;
    private Text TeamName;
    
    void Awake ()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } 
        else
        {
            Destroy(this.gameObject);
        }
    }
    
    public void Start()
    {
    
        PlayerName = GameObject.Find ("PlayerName").GetComponent<Text> ();
        TeamName = GameObject.Find ("TeamName").GetComponent<Text> ();
    
        new GameSparks.Api.Requests.AccountDetailsRequest ()
            .SetDurable(true)
            .Send ((response) => {
                PlayerName.text = PersistentPlayerName = response.DisplayName;
            }  );
    
        new GameSparks.Api.Requests.GetMyTeamsRequest()
            .SetDurable(true)
            .Send(teamResp => {
                if(!teamResp.HasErrors)
                {
                    foreach(var teams in teamResp.Teams)
                    {
                        Debug.Log("Equipo: " + teams.TeamId);
                        TeamName.text = PersistentTeamName = teams.TeamId;
    
                    }
    
                }
            }  );
    }
    }
