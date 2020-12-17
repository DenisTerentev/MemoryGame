﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIStart : MonoBehaviour
{
    [SerializeField] private SceneController controller;
    public void OnMouseEnter()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if(sprite !=null)
        sprite.color = Color.green;
    }
    public void OnMouseExit()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if(sprite!=null)
        sprite.color = Color.white;
    }
    public void OnMouseDown()
    {
        transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
    }
    public void OnMouseUp()
    {
        transform.localScale = new Vector3(0.4f,0.4f,0.4f);
        controller.Restart();

    }
}
