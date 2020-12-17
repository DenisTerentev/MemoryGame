using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    [SerializeField] private GameObject cardBack;
    [SerializeField] private SceneController controller;
    private int _id;
    public int ID
    {
        get { return _id; }
    }

    public void SetCard(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }


    public void OnMouseDown()
    {
        if (!controller.IsOpen)
        {
            if (cardBack.activeSelf) cardBack.SetActive(false);
            controller.CardRevaled(this);
        }
    }
    public void CloseCard()
    {
        this.cardBack.SetActive(true);
    }
}
