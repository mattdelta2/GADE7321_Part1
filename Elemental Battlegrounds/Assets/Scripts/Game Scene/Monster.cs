using UnityEngine;

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

public class Monster : MonoBehaviour
{
    public ElementType element;
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
        if (element == ElementType.Water && otherMonster.element == ElementType.Fire ||
            element == ElementType.Fire && otherMonster.element == ElementType.Plant ||
            element == ElementType.Plant && otherMonster.element == ElementType.Air ||
            element == ElementType.Air && otherMonster.element == ElementType.Earth ||
            element == ElementType.Earth && otherMonster.element == ElementType.Lightning ||
            element == ElementType.Lightning && otherMonster.element == ElementType.Sun ||
            element == ElementType.Sun && otherMonster.element == ElementType.Water)
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
