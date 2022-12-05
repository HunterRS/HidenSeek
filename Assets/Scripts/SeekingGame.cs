using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class SeekingGame : NetworkBehaviour
{

    public NetworkObject playerPrefab;
    public NetworkObject playerObject;
    public Transform[] spawnPosition;
    public int spawnNum = -1;

    public override void Spawned()
    {
        foreach (var player in Runner.ActivePlayers)
        {
            spawnNum += 1;
            NetworkObject playerObject = Runner.Spawn(playerPrefab, spawnPosition[spawnNum].position, Quaternion.identity, player);
            Runner.SetPlayerObject(player, playerObject);
            Runner.SetPlayerAlwaysInterested(player, playerObject, true);
        }
    }
}
