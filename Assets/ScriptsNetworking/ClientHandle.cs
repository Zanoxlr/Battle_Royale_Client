using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ClientHandle : MonoBehaviour
{
    public static void Welcome(Packet _packet)
    {
        string _msg = _packet.ReadString();
        int _myId = _packet.ReadInt();

        Debug.Log($"Message from server: {_msg}");
        Client.instance.myId = _myId;
        ClientSend.WelcomeReceived();

        
        //Now that we have the client's id, connect UDP
        Client.instance.udp.Connect(((IPEndPoint)Client.instance.tcp.socket.Client.LocalEndPoint).Port);
    }
    public static void SpawnPlayer(Packet _packet)
    {
        int _id = _packet.ReadInt();
        string _username = _packet.ReadString();
        Vector3 _position = _packet.ReadVector3();
        Quaternion _rotation = _packet.ReadQuaternion();

        GameManager.instance.SpawnPlayer(_id, _username, _position, _rotation);
    }
    public static void PlayerPosition(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Vector3 _position = _packet.ReadVector3();

        GameManager.players[_id].transform.position = _position;
    }
    public static void PlayerRotation(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Quaternion _rotation = _packet.ReadQuaternion();

        GameManager.players[_id].transform.rotation = _rotation;
    }
    public static void PlayerHealth(Packet _packet)
    {
        int _id = _packet.ReadInt();
        float _health = _packet.ReadFloat();

        GameManager.players[_id].HealthTxtChange(_health);
    }
    public static void PlayerAmmo(Packet _packet)
    {
        int _id = _packet.ReadInt();
        int _ammo = _packet.ReadInt();

        GameManager.players[_id].AmmoTxtChange(_ammo);
    }
    public static void PlayerAmmoInMag(Packet _packet)
    {
        int _id = _packet.ReadInt();
        int _ammoInMag = _packet.ReadInt();

        GameManager.players[_id].AmmoInMagTxtChange(_ammoInMag);
    }
    public static void PlayerWeapon(Packet _packet)
    {
        int _id = _packet.ReadInt();
        int _wpId = _packet.ReadInt();

        GameManager.players[_id].weaponId = _wpId;
        GameManager.players[_id].WeaponSwitch();
    }
    public static void PlayerSounds(Packet _packet)
    {
        Vector3 _vec3 = _packet.ReadVector3();
        int soundIndex = _packet.ReadInt();

        Client.instance.PlaySoundsOnClient(_vec3, soundIndex);
    }
    public static void PlayerRemove(Packet _packet)
    {
        int _id = _packet.ReadInt();
        PlayerManager pm = GameManager.players[_id];
        if (_id != pm.id)
        {
            Destroy(pm.gameObject);
            GameManager.players.Remove(_id);
        }
        else
        {
            Client.instance.Disconnect();
        }
    }
    public static void GameTimer(Packet _packet)
    {
        int timer = _packet.ReadInt();
        string message = _packet.ReadString();

        UIManager.instance.TimerTxtChange(timer, message);
    }
    public static void KillFeed(Packet _packet)
    {
        string killer = _packet.ReadString();
        string killed = _packet.ReadString();
        int weaponId = _packet.ReadInt();

        UIManager.instance.KillFeed(killer, killed, weaponId);
    }
    public static void PlayerKillCount(Packet _packet)
    {
        int _killCount = _packet.ReadInt();

        UIManager.instance.KillCount(_killCount);
    }
    public static void ZoneValues(Packet _packet)
    {
        Vector3 zonePos = _packet.ReadVector3();
        float zoneScale = _packet.ReadFloat();

        GameManager.instance.ZoneValues(zonePos, zoneScale);
    }
    public static void pEE(Packet _packet)
    {
        int id = _packet.ReadInt();
        bool postProcesingEffect = _packet.ReadBool();

        GameManager.players[id].pPE(postProcesingEffect);
    }
    public static void Placement(Packet _packet)
    {
        int id = _packet.ReadInt();
        int placementNum = _packet.ReadInt();

        GameManager.players[id].Placement(placementNum);
    }
    public static void InstatiateObj(Packet _packet)
    {
        int instantNum = _packet.ReadInt();
        Vector3 position = _packet.ReadVector3();

        GameManager.instance.InstaniateObj(instantNum, position);
    }
    public static void PickableRemove(Packet _packet)
    {
        string nameOfObject = _packet.ReadString();
        Debug.Log(nameOfObject);
        Destroy(GameManager.instance.PropsParent.transform.Find(nameOfObject).gameObject);

    }
}