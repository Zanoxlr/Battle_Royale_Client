using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static Dictionary<int, PlayerManager> players = new Dictionary<int, PlayerManager>();
    public GameObject localPlayerPrefab;
    public GameObject playerPrefab;
    public Transform zoneObject;
    public GameObject[] objArray;
    public GameObject PropsParent;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }
    /// <summary>Spawns a player.</summary>
    public void SpawnPlayer(int _id, string _username, Vector3 _position, Quaternion _rotation)
    {
        GameObject _player;
        if (_id == Client.instance.myId)
        {
            _player = Instantiate(localPlayerPrefab, _position, _rotation);
        }
        else
        {
            _player = Instantiate(playerPrefab, _position, _rotation);
        }

        _player.GetComponent<PlayerManager>().id = _id;
        _player.GetComponent<PlayerManager>().username = _username;
        players.Add(_id, _player.GetComponent<PlayerManager>());
    }
    public void ZoneValues(Vector3 _zonePos,float _zoneScale)
    {
        zoneObject.position = _zonePos;
        zoneObject.localScale = new Vector3(_zoneScale, 1, _zoneScale);
    }
    public void InstaniateObj(int objNum, Vector3 position)
    {
        Instantiate(objArray[objNum], position, Quaternion.identity, PropsParent.transform);
    }
}
