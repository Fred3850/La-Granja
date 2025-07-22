using UnityEngine;
using System.Collections;

public class Tomatevida : MonoBehaviour
{
    public float tiempoEspera = 8f;
    public Animator animator;
    public int estadoTomate = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(CambiarEstado());   
    }

  
    private IEnumerator CambiarEstado(){
        while(estadoTomate < 4){
            animator.SetInteger("estado", estadoTomate);
            estadoTomate ++;
            yield return new WaitForSeconds(tiempoEspera);
        }
    }
}