using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using TMPro;

public class PlayerCorrectGuess : NetworkBehaviour
{

    public NetworkObject player;
    public GameObject UI;
    [Networked (OnChanged = nameof(PlayerCorrect))]
    public NetworkBool PlayerWon {get; set;} = false;
    // Start is called before the first frame update
    void Start()
    {
        player = Runner.GetPlayerObject(Runner.LocalPlayer);

    }

    public static void PlayerCorrect(Changed<PlayerCorrectGuess> Changed)
    {
        Changed.Behaviour.UI = GameObject.FindWithTag("GuessUI");

        TextMeshProUGUI mText = Changed.Behaviour.UI.GetComponent<TextMeshProUGUI>();
        mText.text = "PLAYER WON";
    }

    // Update is called once per frame
    void Update()
    {
    }

    [Rpc(RpcSources.All, RpcTargets.All)]
    public void RPC_WinGame(RpcInfo info = default)
    {
        UI = GameObject.FindWithTag("GuessUI");

        TextMeshProUGUI mText = UI.GetComponent<TextMeshProUGUI>();
        mText.text = "PLAYER WON";
    }

    private void OnMouseDown()
    {
        RPC_WinGame();
        //PlayerWon = true;
        Debug.Log(Runner.LocalPlayer.PlayerId);

    }
}
