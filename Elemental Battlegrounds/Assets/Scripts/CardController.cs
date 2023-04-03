using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class CardController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{


    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        float r = UnityEngine.Random.Range(0, 10);
        float g = UnityEngine.Random.Range(0, 10);
        float b = UnityEngine.Random.Range(0, 10);
        image.color = new Color(r, g, b);
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(transform.root);
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(CardManager.LastEnteredDropZone);
        image.raycastTarget = true;
    }
}
