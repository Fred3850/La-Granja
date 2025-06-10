using UnityEngine;
using UnityEngine.InputSystem; 

public class MovimientoJugador : MonoBehaviour
{
    public Vector2 entrada;
    Rigidbody2D rb;
    public float velocidad = 5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = velocidad * entrada;
    }

    public void Movimiento(InputAction.CallbackContext contexto){
         

         entrada = contexto.ReadValue<Vector2>(); 
         Debug.Log("Contexto " + entrada);

    }    
}
