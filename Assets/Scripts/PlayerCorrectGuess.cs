using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using TMPro;

public class PlayerCorrectGuess : NetworkBehaviour
{

    public NetworkObject player;
    public GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        player = Runner.GetPlayerObject(Runner.LocalPlayer);

    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnMouseDown()
    {
        Debug.Log("GUESS");
        UI = GameObject.FindWithTag("GuessUI");

        TextMeshProUGUI mText = UI.GetComponent<TextMeshProUGUI>();
        mText.text = "PLAYER WON";
    }
}
