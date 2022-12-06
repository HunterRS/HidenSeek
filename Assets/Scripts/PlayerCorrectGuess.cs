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
    public void RPC_WinGame(int host, RpcInfo info = default)
    {
        UI = GameObject.FindWithTag("GuessUI");

        TextMeshProUGUI mText = UI.GetComponent<TextMeshProUGUI>();

        if (host == 0)
        {
            mText.text = "Host wins!";
        }
        else if (host == 1)
        {
            mText.text = "Client wins!";
        }
    }

    private void OnMouseDown()
    {
        //PlayerWon = true;
        Debug.Log(Runner.LocalPlayer.PlayerId);
        if (Runner.LocalPlayer.PlayerId == 0)
        {
            RPC_WinGame(1);
        }
        else if (Runner.LocalPlayer.PlayerId != 0)
        {
            RPC_WinGame(0);
        }
    }
}
