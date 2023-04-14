using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class ElementSelection : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] private Button[] elementButtons;
    private List<ElementType> selectedElements = new List<ElementType>();

    private void Start()
    {
        // Enable all element buttons
        foreach (Button button in elementButtons)
        {
            button.interactable = true;
        }
    }

    public void SelectElement(int elementIndex)
    {
        // Check if the element has already been selected
        ElementType selectedElement = (ElementType)elementIndex;
        if (selectedElements.Contains(selectedElement))
        {
            Debug.Log("This element has already been selected.");
            return;
        }

        // Add the selected element to the list
        selectedElements.Add(selectedElement);

        // Disable the selected element button
        elementButtons[elementIndex].interactable = false;

        // Check if all players have selected their element
        if (selectedElements.Count == gameController.NumPlayers)
        {
            // Set the selected elements for each player in the game controller
            //gameController.SetSelectedElement(selectedElement.ToArray());

            // Start the game
            //gameController.StartGameplay();
        }
    }
}
