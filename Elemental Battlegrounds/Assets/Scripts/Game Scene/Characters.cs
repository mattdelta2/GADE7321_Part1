using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Characters : MonoBehaviour
{
    public string MonsterName;
    public Sprite MonsterImage;
    public string MonsterDescription;
    public ElementType MonsterElement;

    



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


