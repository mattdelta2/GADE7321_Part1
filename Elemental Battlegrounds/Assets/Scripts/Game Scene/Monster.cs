using UnityEngine;

public enum Element
{
    Earth,
    Water,
    Fire,
    Air,
    Plant,
    Lightning,
    Sun
}

public class Monster : MonoBehaviour
{
    public Element element;
    public bool isPlayer1;
    public int health = 20;

    public bool isBlocking;
    public bool isAttacking;
    public bool isHealing;

    public int attackDamage = 3;
    public int blockAmount = 2;
    public int healAmount = 2;

    public void Block()
    {
        isBlocking = true;
        isAttacking = false;
        isHealing = false;
    }

    public void Attack()
    {
        isBlocking = false;
        isAttacking = true;
        isHealing = false;
    }

    public void Heal()
    {
        isBlocking = false;
        isAttacking = false;
        isHealing = true;
    }

    public int CalculateDamage(Monster otherMonster)
    {
        int damage = attackDamage;
        if (element == Element.Water && otherMonster.element == Element.Fire ||
            element == Element.Fire && otherMonster.element == Element.Plant ||
            element == Element.Plant && otherMonster.element == Element.Air ||
            element == Element.Air && otherMonster.element == Element.Earth ||
            element == Element.Earth && otherMonster.element == Element.Lightning ||
            element == Element.Lightning && otherMonster.element == Element.Sun ||
            element == Element.Sun && otherMonster.element == Element.Water)
        {
            damage += 1; // elemental advantage
        }

        if (otherMonster.isBlocking)
        {
            damage -= otherMonster.blockAmount;
        }

        return damage;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
    }

    public bool IsDead()
    {
        return health <= 0;
    }
}
