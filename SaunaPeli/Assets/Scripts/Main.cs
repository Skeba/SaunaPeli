using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public GameSceneController gameSceneController;
    protected float halfWidth;
    protected float halfHeight;
    private SpriteRenderer spriteRenderer;
    protected Rigidbody2D rb;



    // Start is called before the first frame update
    protected virtual void Start()
    {
        gameSceneController = FindObjectOfType<GameSceneController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        halfWidth = spriteRenderer.bounds.extents.x;
        halfHeight = spriteRenderer.bounds.extents.y;
    }

}
