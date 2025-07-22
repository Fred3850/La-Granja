using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int contadorHuevo;

    void Awake(){

        if(instance == null){
            instance = this;
        }else {
            Destroy(gameObject);
        }


        DontDestroyOnLoad(gameObject);
    }

    public void SumarHuevo(){
        contadorHuevo++;
        Debug.Log(contadorHuevo);
    }
}
