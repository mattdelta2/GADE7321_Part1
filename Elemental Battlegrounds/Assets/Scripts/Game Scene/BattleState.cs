using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    public GameObject PlayerPrefab;

    public GameObject EnemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;



    public battleState state;
    // Start is called before the first frame update
    void Start()
    {

        state = battleState.Start;
        SetUpBattle();
    }



    void SetUpBattle()
    {

        Instantiate(PlayerPrefab, playerBattleStation);
        Instantiate(EnemyPrefab, enemyBattleStation);

    }
  
}