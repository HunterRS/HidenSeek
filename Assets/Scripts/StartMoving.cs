using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMoving : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.Find("NPCPrefab").SendMessage("GoToLocation");

            this.gameObject.SetActive(false);
        }
    }
}
