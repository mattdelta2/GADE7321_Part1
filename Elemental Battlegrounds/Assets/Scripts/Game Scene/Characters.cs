using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Character", menuName ="Game/Character")]
public class Characters : ScriptableObject
{
    public string CharacterName;
    public CharacterClass characterClass;
    public Card[] startingCards;



}

public enum CharacterClass
{
    Earth,
    Water,
    Fire,
    Air,
    Plant,
    Lighting,
    Sun,
 
}
[System.Serializable]
public class Card
{
    public int Damage = 3;
    
}


