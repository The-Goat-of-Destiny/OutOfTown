using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerData
{
    public string Username;
    public int Icon;
    public int Skin;

    public PlayerData(string _username="Player", int _icon = 0, int _skin = 0)
    {
        Username = _username;
        Icon = _icon;
        Skin = _skin;
    }
}
