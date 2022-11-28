using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class SeekingGame : NetworkBehaviour
{

    public NetworkObject playerPrefab;
    public Transform spawnPosition;

    public override void Spawned()
    {
        foreach (var player in Runner.ActivePlayers)
        {
            NetworkObject playerObject = Runner.Spawn(playerPrefab, spawnPosition.position, Quaternion.identity, player);
            Runner.SetPlayerObject(player, playerObject);
            Runner.SetPlayerAlwaysInterested(player, playerObject, true);
        }
    }
}
