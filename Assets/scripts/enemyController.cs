using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public float velocidad = 5;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Esto se crea una unica vez");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
     
        rb.velocity = new Vector2(-velocidad, rb.velocity.y);//velocidad de mi objeto
        spriteRenderer.flipX = true;
    }
      private void CambiarAnimacion(int animacion)
    {
       
    }
      
}
