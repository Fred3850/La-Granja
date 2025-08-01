using UnityEngine;
using UnityEngine.InputSystem; 

public class MovimientoJugador : MonoBehaviour
{
    public Vector2 entrada;
    Rigidbody2D rb;
    public float velocidad = 5f;
    private Animator animator;
    public GameObject trigoPreFab;
    public GameObject tomatePreFab;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = velocidad * entrada;
    }

    public void Movimiento(InputAction.CallbackContext contexto){

        Vector2 valorEntrada = contexto.ReadValue<Vector2>();

        animator.SetBool("estaCaminando", true);

        // Determinar el eje dominante
        if (Mathf.Abs(valorEntrada.x) > Mathf.Abs(valorEntrada.y))
        {
            // Movimiento horizontal
            entrada = new Vector2(Mathf.Sign(valorEntrada.x), 0);
        }
        else if (Mathf.Abs(valorEntrada.y) > 0)
        {
            // Movimiento vertical
            entrada = new Vector2(0, Mathf.Sign(valorEntrada.y));
        }
        else
        {
            entrada = Vector2.zero;
        }

        //asignar valores a los parametros de entradaX y entrdadY

        animator.SetFloat("EntradaX", entrada.x);
        animator.SetFloat("EntradaY", entrada.y);

        if(contexto.canceled){
            animator.SetBool("estaCaminando", false);
        }
    }   

    public void SembrarTrigo(InputAction.CallbackContext contexto){
        if(contexto.started){
            Instantiate(trigoPreFab, transform.position, Quaternion.identity);
        }

    }

    public void SembrarTomate(InputAction.CallbackContext contexto){
        if(contexto.started){
            Instantiate(tomatePreFab, transform.position, Quaternion.identity);
        }

    }

    public void OnTriggerEnter2D(Collider2D colision){
        if(colision.CompareTag("Huevo")){
            Destroy(colision.gameObject);
            GameManager.instance.SumarHuevo();


            //Debug.Log("Colision con Huevo");
        }
    } 
}
