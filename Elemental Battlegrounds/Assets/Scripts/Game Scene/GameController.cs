using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public GameObject[] monsters;
    public GameObject player1;
    public GameObject player2;
    public GameObject[] elements;
    public GameObject currentElement;
    public int currentTurn;
    public Text turnText;
    public Text player1Health;
    public Text player2Health;
    public bool gameOver = false;
    public int[] elementCount = new int[7];

    private int currentPlayerIndex = 0;
    public int NumPlayers { get; set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        int randMonster = Random.Range(0, monsters.Length);
        player1 = Instantiate(monsters[randMonster], new Vector3(-5, 0, 0), Quaternion.identity);
        player1.GetComponent<Monster>().isPlayer1 = true;

        int[] availableElements = new int[4];
        int index = 0;
        while (index < 4)
        {
            int randElement = Random.Range(0, elements.Length);
            if (elementCount[randElement] < 2)
            {
                elementCount[randElement]++;
                availableElements[index] = randElement;
                index++;
            }
        }

        for (int i = 0; i < availableElements.Length; i++)
        {
            GameObject newElement = Instantiate(elements[availableElements[i]], new Vector3(-2.5f + i * 2, 2, 0), Quaternion.identity);
            //newElement.GetComponent<ElementType>().index = i;
        }

        currentTurn = Random.Range(1, 3);
        if (currentTurn == 1)
        {
            turnText.text = "Player 1's Turn";
        }
        else
        {
            turnText.text = "Player 2's Turn";
        }
    }

    void Update()
    {
        if (!gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                EndTurn();
            }
        }
    }

    public void EndTurn()
    {
        if (currentTurn == 1)
        {
            currentTurn = 2;
            turnText.text = "Player 2's Turn";
        }
        else
        {
            currentTurn = 1;
            turnText.text = "Player 1's Turn";
        }
        currentElement = null;
        player1.GetComponent<Monster>().isAttacking = false;
        player2.GetComponent<Monster>().isAttacking = false;
    }

    public void GameOver(string winner)
    {
        gameOver = true;
        turnText.text = winner + " wins!";
    }

    public void SetCurrentElement(GameObject element)
    {
        currentElement = element;
    }

    public void SetPlayer1(GameObject player)
    {
        player1 = player;
    }

    public void SetPlayer2(GameObject player)
    {
        player2 = player;
    }

    public void UpdateHealth(int player, int health)
    {
        if (player == 1)
        {
            player1Health.text = "Player 1: " + health.ToString() + " HP";
        }
        else
        {
            player2Health.text = "Player 2: " + health.ToString() + " HP";
        }
        if (health <= 0)
        {
            GameOver("Player " + (3 - player).ToString());
        }
    }

    public int GetCurrentPlayerIndex()
    {
        return currentPlayerIndex;
    }

    public void SetSelectedElement(ElementType selectedElement)
{
    //this.SelectedElement = selectedElement;
}

}

