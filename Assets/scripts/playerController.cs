using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
      public float velocidad = 5;
  
    private bool EstaSaltando = false;
    private bool EstaDeslizando = false;
    private bool EstaDestruido = false;
    private bool EstaCorriendo=true;
    public float fuerzaSalto = 15;
    public GameObject enemy;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;
    
    private const int ANIMATION_QUIETO = 0;
    
    private const int ANIMATION_CORRER = 1;
    private const int ANIMATION_SALTAR = 2;   
    private const int ANIMATION_DESLIZAR =3;
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
        
        if(EstaSaltando==false){
            CambiarAnimacion(ANIMATION_CORRER);//Accion correr 
            rb.velocity = new Vector2(velocidad, rb.velocity.y);//velocidad de mi objeto
            spriteRenderer.flipX = false;
            EstaDeslizando=false;
        } if(Input.GetKey(KeyCode.Space))
        {
            
            EstaSaltando=true;
            if(EstaSaltando==true){
                CambiarAnimacion(ANIMATION_SALTAR);
                Saltar();
            }else{
                CambiarAnimacion(ANIMATION_CORRER);
                
            }
         
        } if(Input.GetKey(KeyCode.X))
        {
            EstaDeslizando=true;
            if(EstaDeslizando==true){
                CambiarAnimacion(ANIMATION_DESLIZAR);
            }else{
                CambiarAnimacion(ANIMATION_CORRER);
            }
        }
       
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "suelo"){
            EstaSaltando = false;
        } 
        if(collision.gameObject.tag == "enemy"&&EstaDeslizando == true){
            Destroy(collision.gameObject);
        }else if(collision.gameObject.tag == "enemy" ){
            Destroy(this.gameObject);
        }

    }
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "enemy"){
            velocidad =velocidad+1.5f;
            Debug.Log("velocidad: "+velocidad);
        } 

    }
    private void Saltar()
    {
      
        rb.velocity = Vector2.up * fuerzaSalto;//Vector 2.up es para que salte hacia arriba
        
    }
      private void CambiarAnimacion(int animacion)
    {
        animator.SetInteger("Estado", animacion);
    }
}
