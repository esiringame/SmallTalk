﻿using UnityEngine;

public class HideoutBehaviour : MonoBehaviour
{
    public Sprite FullSprite;
    public Sprite EmptySprite;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = EmptySprite;
    }

    private void Fill()
    {
        _spriteRenderer.sprite = FullSprite;
        Debug.Log("Ou pas faut voir");
    }

    private void Empty()
    {
        _spriteRenderer.sprite = EmptySprite;
    }

    public void OnHide()
    {
        Debug.Log("C'est caché");
        Fill();
    }

    public void OnUnhide()
    {
        Empty();
    }
}