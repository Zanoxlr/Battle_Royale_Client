using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class ComponentsToDisable : NetworkBehaviour
{
    public List<Behaviour> Components = new List<Behaviour>();
    [Client]
    private void Start()
    {
        if (!isLocalPlayer)
        {
            for(int i = 0; i < Components.Count; i++)
            {
                Components[i].enabled = false;
            }
        }
        else
        {
            Camera.main.gameObject.SetActive(true);
        }
    }
}
