using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public Text selectedElementsText;

    public List<ElementType> AvailableElements;
    public List<ElementType> SelectedElements;
    public int maxSelectedElements = 2;

    private int numSelectedElements = 0;


    public static CharacterSelection Instance { get; private set; }







    void start()
    {
        // Randomly select four elements from the list of available elements
        int numElementsToSelect = 4;

        while(SelectedElements.Count<numElementsToSelect && AvailableElements.Count >0)
        {
            int randomIndex = Random.Range(0, AvailableElements.Count);
            ElementType randomElement = AvailableElements[randomIndex];
            SelectedElements.Add(randomElement);
            AvailableElements.RemoveAt(randomIndex);
        }

        UpdateSelectedElementsText();

    }

    public void SelectElements(ElementType element)
    {
        if (numSelectedElements<maxSelectedElements && !SelectedElements.Contains(element))
        {
            SelectedElements.Add(element);
            numSelectedElements++;


            UpdateSelectedElementsText();

        }

    }

    private void UpdateSelectedElementsText()
    {
        string text = "Selected Elements: ";
        foreach(ElementType element in SelectedElements)
        {
            text += element.ToString() + " ";

        }
        selectedElementsText.text = text;
    }


    public void StartGame()
    {

        if(SelectedElements.Count ==2)
        {
            string[] elements = SelectedElements.ToArray();
            SaveManager saveManager = FindObjectOfType<SaveManager>();
            saveManager.SaveElements(elements);


            SceneManager.LoadScene("GameScene");

        }
        else
        {
            Debug.Log("Please select exactly 2 elements");
        }
    }

    public void UpdateSelectedElements(ElementType element)
    {
        if(SelectedElements.Contains(element))
        {
            SelectedElements.Remove(element);

        }
        else if (SelectedElements.Count<2)
        {
            SelectedElements.Add(element);
        }

        UpdateSelectedElementsText();
    }
    


}