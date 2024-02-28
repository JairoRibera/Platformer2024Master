using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    //Velocidad del enemigo
    public float moveSpeed;
    //Posiciones m�s a la izquierda y m�s a la derecha que se va a poder mover el enemigo
    public Transform leftPoint, rightPoint;
    //Variable para conocer la direcci�n de movimiento del enemigo
    public bool movingRight;

    //Referencia al Rigidbody del enemigo
    private Rigidbody2D _rB;
    //Referencia al SpriteRenderer
    private SpriteRenderer _sR;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializamos la referencia del Rigidbody
        _rB = GetComponent<Rigidbody2D>();
        //Inicializamos el SpriteRenderer del enemigo teniendo en cuenta que est� en el GO hijo
        _sR = GetComponentInChildren<SpriteRenderer>();

        //Sacamos el Leftpoint y el Rightpoint del objeto padre, para que no se muevan junto con este
        leftPoint.parent = null;
        rightPoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        //Si el enemigo se est� movimiendo hacia la derecha
        if (movingRight)
        {
            //Aplicamos una velocidad a la derecha al enemigo
            _rB.velocity = new Vector2(moveSpeed, _rB.velocity.y);
            //Giramos en horizontal el sprite del enemigo
            _sR.flipX = true;

            //Si la posici�n en X del enemigo est� m�s a la derecha que el RightPoint
            if (transform.position.x > rightPoint.position.x)
                //Ya no se mover� a la derecha sino a la izquierda
                movingRight = false;
        }
        //Si el enemigo se est� movimiendo hacia la izquierda
        else
        {
            //Aplicamos una velocidad a la izquierda al enemigo
            _rB.velocity = new Vector2(-moveSpeed, _rB.velocity.y);
            //Giramos en horizontal el sprite del enemigo
            _sR.flipX = false;

            //Si la posici�n en X del enemigo est� m�s a la izquierda que el LeftPoint
            if (transform.position.x < leftPoint.position.x)
                //Ya no se mover� a la izquierda sino a la derecha
                movingRight = true;
        }

    }
}
