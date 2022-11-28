using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Fusion;
using System.Linq;

public class LobbyScript : NetworkBehaviour
{
    public GameObject playerAvatar;
    public TMP_Text txtConnected;
    private GameSpawner _cSpawner;

    public override void Spawned()
    {
        _cSpawner = GameObject.FindObjectOfType<GameSpawner>();
    }
    // Start is called before the first frame update
    public void FixedUpdate()
    {
        //txtConnected.text = "Players Connected: " + _cSpawner._runner.ActivePlayers.Count().ToString();
    }


    public void StartGame()
    {
        _cSpawner.StartGameplay();
    }

    public void ChangeShirt()
    {
        playerAvatar.GetComponent<LocalCharacterCustomizer>().NextSkinLocal();
    }
}
