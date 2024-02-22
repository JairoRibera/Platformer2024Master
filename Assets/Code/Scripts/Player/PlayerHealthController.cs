using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    //Variables para controlar la vida actual del jugador y el m�ximo de vida que puede tener
    //[HideInInspector] -> es un atributo de la variable que me permite que una variable no sea visible en el editor de Unity pero se mantenga p�blica
    [HideInInspector] public int currentHealth;
    public int maxHealth;

    //Referencia al UIController
    private UIController _uIReference;
    //Referencia al PlayerController
    private PlayerController _pCReference;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializamos la referencia de UIController
        _uIReference = GameObject.Find("Canvas").GetComponent<UIController>();
        //Inicializamos la referencia al PlayerController
        _pCReference = GetComponent<PlayerController>();
        //Inicializamos la vida del jugador
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //M�todo para manejar el da�o
    public void DealWithDamage()
    {
        //Restamos 1 de la vida que tengamos
        currentHealth--; //_currentHealth -= 1 <=> _currentHealth = _currentHealth - 1 <=> _currentHealth--
        
        //Si la vida est� en 0 o por debajo (para asegurarnos de tener en cuenta solo valores positivos)
        if(currentHealth <= 0)
        {
            //Hacemos que la vida se ponga a cero si se queda en negativo
            currentHealth = 0;

            //Hacemos desaparecer de momento al jugador
            gameObject.SetActive(false);
        }
        //Si el jugador ha recibido da�o pero no ha muerto
        else
        {
            //Llamamos al m�todo que hace que el jugador realice el KnockBack
            _pCReference.Knockback();
        }

        //Actualizamos la UI (los corazones)
        _uIReference.UpdateHealthDisplay();
    }
}
