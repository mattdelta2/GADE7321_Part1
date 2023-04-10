using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    public string monsterName;
    public Sprite monsterImage;
    public string MonsterDespcription;
    public ElementType monsterElement;
}

public enum ElementType
{
    Earth,
    Water,
    Fire,
    Air,
    Plant,
    Lightning,
    Sun
}
