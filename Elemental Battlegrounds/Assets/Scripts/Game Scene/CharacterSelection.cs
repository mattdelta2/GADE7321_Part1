using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CharacterSelection : MonoBehaviour
{
    public Button[] elementButtons;
    public Text[] selectedElements;
    public string[] availableElements = { "Earth", "Water", "Fire", "Air", "Plant", "Lightning", "Sun" };
    public string[] selectedMonster = new string[2];
    public string[] selectedElement = new string[2];

    void Start()
    {
        // Shuffle available elements
        System.Random rnd = new System.Random();
        for (int i = 0; i < availableElements.Length; i++)
        {
            int r = i + (int)(rnd.NextDouble() * (availableElements.Length - i));
            string temp = availableElements[r];
            availableElements[r] = availableElements[i];
            availableElements[i] = temp;
        }

        // Set element buttons text
        for (int i = 0; i < elementButtons.Length; i++)
        {
            elementButtons[i].GetComponentInChildren<Text>().text = availableElements[i];
        }
    }

    public void SelectMonster(string monsterName)
    {
        int playerIndex = GameController.Instance.GetCurrentPlayerIndex();
        selectedMonster[playerIndex] = monsterName;
    }

    public void SelectElement(int elementIndex)
    {
        int playerIndex = GameController.Instance.GetCurrentPlayerIndex();
        selectedElement[playerIndex] = availableElements[elementIndex];

        // Remove selected element from available elements
        List<string> tempList = new List<string>(availableElements);
        tempList.RemoveAt(elementIndex);
        availableElements = tempList.ToArray();

        // Update element buttons text
        for (int i = 0; i < elementButtons.Length; i++)
        {
            elementButtons[i].GetComponentInChildren<Text>().text = availableElements[i];
        }

        // Update selected elements text
        selectedElements[playerIndex].text = "Selected Element: " + selectedElement[playerIndex];
    }
}
