using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public List<ElementType> AvailableElements;
    public List<ElementType> SelectedElements;



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
    }

}