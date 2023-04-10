using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ElementalSelection : MonoBehaviour
{
    public List<ElementType> availableElements;
    public List<ElementType> selectedElements;
    public TextMesh selectedElementsText;
    public int maxSelectedElements = 2;

    private int numSelectedElements = 0;

    void Start()
    {
        // Randomly select four elements from the list of available elements
        int numElementsToSelect = 4;
        while (selectedElements.Count < numElementsToSelect && availableElements.Count > 0)
        {
            int randomIndex = Random.Range(0, availableElements.Count);
            ElementType randomElement = availableElements[randomIndex];
            selectedElements.Add(randomElement);
            availableElements.RemoveAt(randomIndex);
        }

        // Update the text to display the selected elements
        UpdateSelectedElementsText();
    }

    public void SelectElement(ElementType element)
    {
        if (numSelectedElements < maxSelectedElements && !selectedElements.Contains(element))
        {
            selectedElements.Add(element);
            numSelectedElements++;

            // Update the text to display the selected elements
            UpdateSelectedElementsText();
        }
    }

    private void UpdateSelectedElementsText()
    {
        string text = "Selected Elements: ";
        foreach (ElementType element in selectedElements)
        {
            text += element.ToString() + " ";
        }
        selectedElementsText.text = text;
    }


}