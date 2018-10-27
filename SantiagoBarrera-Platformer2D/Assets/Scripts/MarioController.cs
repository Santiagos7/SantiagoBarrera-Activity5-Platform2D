using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioController : MonoBehaviour {

    public Animator animatorMario;
    bool isRunning = false;

    // Use this for initialization
    void Start()
    {

        //Referenccia componenete animator
        animatorMario = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //Por default,, suponemos que el ususario no esta presionando
        // las flechas
        isRunning = false;


        //Flecha izquierda
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            this.transform.Translate(Vector3.left * 0.1f);
            isRunning = true;
            this.GetComponent<SpriteRenderer>().flipX = true;

        }

        // flecha derecha
        if (Input.GetKey(KeyCode.RightArrow))
        {

            this.transform.Translate(Vector3.right * 0.1f);
            isRunning = true;
            this.GetComponent<SpriteRenderer>().flipX = false;

        }

        //Movineod personaje si o no
        animatorMario.SetBool("MarioIsRunning", isRunning);

        //Saltar 
        if (Input.GetKeyDown(KeyCode.Space))
        {

            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 7.0f, ForceMode2D.Impulse);
            animatorMario.SetBool("MarioIsOnfloor", false);
        }

    } //Update end

    //Cuando collider sonic toca otro collider
    void OnCollisionEnter2D(Collision2D col)
    {

        //Avisamos que el salto ha terminado
        animatorMario.SetBool("MarioIsOnfloor", true);
    }


} //Script End
