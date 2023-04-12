using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public enum battleState
{
    Start,
    PlayerTurn,
    EnemyTurn,
    Won,
    Lost
}



public class BattleState : MonoBehaviour
{

    public GameObject [] PlayerPrefab;

    public GameObject [] EnemyPrefab;

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

        //Random Element at the start of the game for enemy

        int randomEnemyElementIndex = Random.Range(0, EnemyPrefab.Length);
        GameObject enemyUnitPrefab = EnemyPrefab[randomEnemyElementIndex];

        GameObject enemyUnit = Instantiate(enemyUnitPrefab, enemyBattleStation);
        enemyUnit.transform.localScale = new Vector3(.1f, .1f, 1);

        EnemyUnit = enemyUnit.GetComponent<Unit>();
        EnemyUnit.element = (Element)randomEnemyElementIndex;



        //Random Element at start of game for player


        int randomPlayerElementIndex = Random.Range(0, PlayerPrefab.Length);
        GameObject playerUnitPrefab = PlayerPrefab[randomPlayerElementIndex];

        GameObject playerUnit = Instantiate(playerUnitPrefab, playerBattleStation);
        playerUnit.transform.localScale = new Vector3(.1f, .1f, 1);
        PlayerUnit = playerUnit.GetComponent<Unit>();
        PlayerUnit.element = (Element)randomPlayerElementIndex;

         

       // GameObject playerGo = Instantiate(PlayerPrefab, playerBattleStation);
        //playerGo.transform.localScale = new Vector3(.1f, .1f, 1);

        //playerUnit = playerGo.GetComponent<Unit>();


        //GameObject enemyGo = Instantiate(EnemyPrefab, enemyBattleStation);
       // enemyGo.transform.localScale = new Vector3(.10f, .10f, 1);
        //EnemyUnit = enemyGo.GetComponent<Unit>();

        dialogueText.text = "You are Currently Fighting a: " + EnemyUnit.unitName;


        playerHUD.SetUpHUD(PlayerUnit);
        enemyHUD.SetUpHUD(EnemyUnit);

        yield return new WaitForSeconds(2f);



        state = battleState.PlayerTurn;
        PlayerTurn();

    }

    IEnumerator PlayerAttack()
    {

        bool isDead = EnemyUnit.TakeDamage(PlayerUnit.damage);


        enemyHUD.SetHP(EnemyUnit.currentHP);

        dialogueText.text = "Damage was dealt";
        yield return new WaitForSeconds(2f);


        if(isDead)
        {
            state = battleState.Won;
            EndBattle();
        }
        else
        {
            state = battleState.EnemyTurn;

            StartCoroutine(EnemyTurn());
        }


    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text = EnemyUnit.unitName + "Attacks";
        yield return new WaitForSeconds(1f);

        bool isDead= PlayerUnit.TakeDamage(EnemyUnit.damage);

        playerHUD.SetHP(PlayerUnit.currentHP);

        yield return new WaitForSeconds(1f);


        if(isDead)
        {
            state = battleState.Lost;
        }
        else
        {
            state = battleState.PlayerTurn;
            PlayerTurn();
        }



    }

    void EndBattle()
    {
        if(state ==battleState.Won)
        {
            dialogueText.text = "You won";

        }
        else if(state ==battleState.Lost)
        {
            dialogueText.text = " You Lost";
        }
    }

    IEnumerator PlayerHeal()
    {

        PlayerUnit.Heal(2);
        playerHUD.SetHP(PlayerUnit.currentHP);
        dialogueText.text = "You have healed";

        yield return new WaitForSeconds(2f);

        state = battleState.EnemyTurn;
        StartCoroutine(EnemyTurn());

    }





    public void PlayerTurn()
    {
        dialogueText.text = "Player 1 Choose an action";
    }



    public void OnAttackButton()
    {
        if(state != battleState.PlayerTurn)
        
            return;
            StartCoroutine(PlayerAttack());
        

    }

    public void OnHealButton()
    {
        if (state != battleState.PlayerTurn)

            return;
        StartCoroutine(PlayerHeal());


    }





}
