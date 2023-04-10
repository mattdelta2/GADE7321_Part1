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
    Moon
}

[System.Serializable]
public class Card
{
    public string CardName;
    public string Description;
    public int Attack;
    public int Health;
}
