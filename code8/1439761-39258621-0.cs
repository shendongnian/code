    using UnityEngine;
    using UnityEngine.Networking;
    using UnityEngine.Networking.Match;
    using UnityEngine.Networking.Types;
    using System.Collections;
    using System.Collections.Generic;
    
    public class MyMatchMaker : MonoBehaviour {
        bool done;
        // Use this for initialization
        void Start () {
            NetworkManager.singleton.StartMatchMaker();
            NetworkManager.singleton.matchMaker.ListMatches(0, 20, "Match", false, 0, 1, OnMatchList);
            Debug.Log("Searching");
        }
    
        public virtual void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matchList)
        {
            if (success)
            {
                if (matchList.Count != 0)
                {
                    Debug.Log("Matches Found");
                    NetworkManager.singleton.matchMaker.JoinMatch(matchList[0].networkId, "", "", "", 0, 1, OnMatchJoined);
                }
                else
                {
                    Debug.Log("No Matches Found");
                    Debug.Log("Creating Match");
                    NetworkManager.singleton.matchMaker.CreateMatch("Match", 2, true, "", "", "", 0, 1, OnMatchCreate);
                }
            }
            else
            {
                Debug.Log("ERROR : Match Search Failure");
            }
        }
    
        public virtual void OnMatchJoined(bool success, string extendedInfo, MatchInfo matchInfo)
        {
            if (success)
            {
                Debug.Log("Match Joined");
                MatchInfo hostInfo = matchInfo;
                NetworkManager.singleton.StartClient(hostInfo);
    
                OnConnect();
            }
            else
            {
                Debug.Log("ERROR : Match Join Failure");
            }
    
        }
    
        public virtual void OnMatchCreate(bool success, string extendedInfo, MatchInfo matchInfo)
        {
            if (success)
            {
                Debug.Log("Match Created");
    
                MatchInfo hostInfo = matchInfo;
                NetworkServer.Listen(hostInfo, 9000);
                NetworkManager.singleton.StartHost(hostInfo);
    
                OnConnect();
            }
            else
            {
                Debug.Log("ERROR : Match Create Failure");
            }
        }
    }
