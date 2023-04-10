using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionButton : MonoBehaviour
{
    public ElementType element;
     public void Start()
    {
        GetComponent<Button>().onClick.AddListener(SelectElement);
        
    }

    public void SelectElement()
    {
        CharacterSelection.Instance.UpdateSelectedElements(element);
        
    }
}
