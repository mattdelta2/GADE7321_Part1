using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Element
{
    Fire,
    Water,
    Wind,
    Lightning,
    Earth,
    Sun,
    Plant
}

public class Unit : MonoBehaviour
{

    public string unitName;

    public int damage;
    public int maxHP;
    public int currentHP;
}
