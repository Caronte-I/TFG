using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour {

    private bool saltando;
    private int vidas;

    // Start is called before the first frame update
    void Start(){
        saltando = false;
        vidas=3;
        
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-0.01f, 0.0f));
        }

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(0.01f, 0.0f));
        }

        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(saltando == false)
            {
               GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 300.0f));
               saltando = true;
            }
            
        }    
    }

    void OnCollisionEnter2D(Collision2D _col)
    {
        if(_col.gameObject.tag == "Suelo")
        {
             saltando = false;
        }
        if(_col.gameObject.tag =="Enemigo")
        {
            _col.gameObject.SetActive(false);
            Destroy(_col.gameObject, 0.5f);
            //vidas--;
            vidas = vidas - 1;
            Debug.Log("Vidas: " + vidas);
            if(vidas <=0)
            {
                Debug.Log("Game Over");
                gameObject.SetActive(false);
            }
        }
        
    }    
}
