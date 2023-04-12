using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public enum battleState
{
    Start,
    Player1Turn,
    Player2Turn,
    Won,
    Lost
}



public class BattleState : MonoBehaviour
{

    public GameObject[] PlayerPrefab;

    public GameObject[] EnemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;


    public Text dialogueText;


    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;


    Unit PlayerUnit;
    Unit EnemyUnit;






    public battleState state;
    // Start is called before the first frame update
    void Start()
    {

        state = battleState.Start;
        StartCoroutine(SetUpBattle());
    }



    IEnumerator SetUpBattle()
    {

        //Random Element at the start of the game for Player2

        int randomEnemyElementIndex = Random.Range(0, EnemyPrefab.Length);
        GameObject enemyUnitPrefab = EnemyPrefab[randomEnemyElementIndex];

        GameObject enemyUnit = Instantiate(enemyUnitPrefab, enemyBattleStation);
        enemyUnit.transform.localScale = new Vector3(.1f, .1f, 1);

        EnemyUnit = enemyUnit.GetComponent<Unit>();
        EnemyUnit.element = (Element)randomEnemyElementIndex;

        EnemyUnit.attack = 2;
        EnemyUnit.defense = 2;



        //Random Element at start of game for player1


        int randomPlayerElementIndex = Random.Range(0, PlayerPrefab.Length);
        GameObject playerUnitPrefab = PlayerPrefab[randomPlayerElementIndex];

        GameObject playerUnit = Instantiate(playerUnitPrefab, playerBattleStation);
        playerUnit.transform.localScale = new Vector3(.1f, .1f, 1);
        PlayerUnit = playerUnit.GetComponent<Unit>();
        PlayerUnit.element = (Element)randomPlayerElementIndex;

        PlayerUnit.attack = 2;
        PlayerUnit.defense = 2;



        // GameObject playerGo = Instantiate(PlayerPrefab, playerBattleStation);
        //playerGo.transform.localScale = new Vector3(.1f, .1f, 1);

        //playerUnit = playerGo.GetComponent<Unit>();


        //GameObject enemyGo = Instantiate(EnemyPrefab, enemyBattleStation);
        // enemyGo.transform.localScale = new Vector3(.10f, .10f, 1);
        //EnemyUnit = enemyGo.GetComponent<Unit>();

        dialogueText.text = PlayerUnit.unitName + " VS " + EnemyUnit.unitName;


        playerHUD.SetUpHUD(PlayerUnit);
        enemyHUD.SetUpHUD(EnemyUnit);

        yield return new WaitForSeconds(2f);



        state = battleState.Player1Turn;
        PlayerTurn();

    }


    IEnumerator Player2Attack()
    {
        bool isDead = PlayerUnit.TakeDamage(EnemyUnit.damage, EnemyUnit.element);

        playerHUD.SetHP(PlayerUnit.currentHP);
        dialogueText.text = "Player 2 did damage";

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = battleState.Won;
           StartCoroutine( EndBattle());
        }
        else
        {
            state = battleState.Player1Turn;
            PlayerTurn();
            
        }
    }

    IEnumerator PlayerAttack()
    {

        bool isDead = EnemyUnit.TakeDamage(PlayerUnit.damage,PlayerUnit.element);


        enemyHUD.SetHP(EnemyUnit.currentHP);

        dialogueText.text = "Player 1 did Damage";
        yield return new WaitForSeconds(2f);


        if (isDead)
        {
            state = battleState.Won;
            StartCoroutine(EndBattle());
        }
        else
        {
            state = battleState.Player2Turn;
            Player2Turn();

            
        }


    }


    /*public void Attack(Unit attacker, Unit defender)
    {
        int damage = attacker.CalculateDamage(defender);
        defender.TakeDamage(damage);

        // Show damage in the UI
        dialogueText.text = attacker.unitName + " attacked " + defender.unitName + " for " + damage + " damage.";

        // Check if the defender is defeated
        if (defender.currentHP <= 0)
        {
            dialogueText.text = defender.unitName + " has been defeated!";


        }
    }*/

    /*
    IEnumerator EnemyTurn()
    {
        dialogueText.text = EnemyUnit.unitName + "Attacks";
        yield return new WaitForSeconds(1f);

        bool isDead = PlayerUnit.TakeDamage(EnemyUnit.damage,EnemyUnit.element);

        playerHUD.SetHP(PlayerUnit.currentHP);

        yield return new WaitForSeconds(1f);


        if (isDead)
        {
            state = battleState.Lost;
        }
        else
        {
            state = battleState.Player1Turn;
            PlayerTurn();
        }
        

        




    }*/

    IEnumerator EndBattle()
    {
        if (state == battleState.Won)
        {
            if(EnemyUnit.currentHP <=0)
            {
                dialogueText.text = "Player 1 Has Become Victorious";
            }
            else if(PlayerUnit.currentHP <=0)
            {
                dialogueText.text = "Player 2 Has Become Victorious";
            }

            yield return new WaitForSeconds(5);

            

        }
        else if (state == battleState.Lost)
        {
            dialogueText.text = " You Lost";
            SceneManager.LoadScene("MainMenu");
        }
    }

    IEnumerator PlayerHeal()
    {

        PlayerUnit.Heal(2);
        playerHUD.SetHP(PlayerUnit.currentHP);
        dialogueText.text = "Player 1 Has Healed for: 2HP";

        yield return new WaitForSeconds(2f);

        state = battleState.Player2Turn;
        Player2Turn();

    }


    IEnumerator Player2Heal()
    {
        EnemyUnit.Heal(2);
        enemyHUD.SetHP(EnemyUnit.currentHP);
        dialogueText.text = "Player 2 Has Healed for: 2HP";


        yield return new WaitForSeconds(2f);
        state = battleState.Player1Turn;
        PlayerTurn();
    }

    IEnumerator Player1Block()
    {
        PlayerUnit.Block(2);
        playerHUD.SetHP(PlayerUnit.currentHP);
        dialogueText.text = "Player 1 Has blocked for 2 damage";

        yield return new WaitForSeconds(2f);
        state = battleState.Player1Turn;
        Player2Turn();

        
    }

    IEnumerator Player2Block()
    {
        EnemyUnit.Block(2);
        enemyHUD.SetHP(EnemyUnit.currentHP);
        dialogueText.text = "Player 2 has blocked for 2 damage";

        yield return new WaitForSeconds(2f);
        PlayerTurn();
    }





    public void PlayerTurn()
    {
        dialogueText.text = "Player 1 Choose an action";
    }


    public void Player2Turn()
    {
        dialogueText.text = "Player 2 Choose an Action";
    }



    public void OnAttackButton()
    {
        if (state != battleState.Player1Turn)

            return;
        StartCoroutine(PlayerAttack());

    }


    public void Player2AttackButton()
    {
        if (state != battleState.Player2Turn)
            return;
        StartCoroutine(Player2Attack());
    }

    public void Player2HealButton()
    {

        if (state != battleState.Player2Turn)
            return;
        StartCoroutine(Player2Heal());

    }

    public void OnHealButton()
    {
        if (state != battleState.Player1Turn)

            return;
        StartCoroutine(PlayerHeal());


    }

    public void Player1BlockButton()
    {
        if (state != battleState.Player1Turn)

            return;
        StartCoroutine(Player1Block());

    }    

    public void Player2BlockButton()
    {
        if (state != battleState.Player2Turn)
            return;
        StartCoroutine(Player2Block());

    }







}
