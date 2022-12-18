using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorControlRoom : MonoBehaviour
{
    public GameObject uiObj;
    public Animator pintuAtas;
    public Animator pintuBawah;

    void Start()
    {
        uiObj.SetActive(false);
    }

    void Awake() 
    {
         GameObject gameObject = GameObject.Find("Top Door Panel");
         pintuAtas = gameObject.GetComponent<Animator> ();

         GameObject gameObject2 = GameObject.Find("Bottom Door Panel");
         pintuBawah = gameObject2.GetComponent<Animator> ();
    }

    /*void OnTriggerEnter(Collider other){
        uiObj.SetActive(true);
        if(other.gameObject.tag == "Player" && Input.GetKeyUp(KeyCode.E)){
            anim.SetBool("open",true);
        }
        else if(Input.GetKeyUp(KeyCode.E)){
            anim.SetBool("close",true);
        }
        
    }*/

    void OnTriggerStay(Collider other){
        uiObj.SetActive(true);
        if(other.gameObject.tag == "Player" && Input.GetKeyUp(KeyCode.E)){
            pintuAtas.SetBool("isOpen",true);
            pintuBawah.SetBool("isOpen",true);
        }
        // else if((Input.GetKeyUp(KeyCode.E)) == false){
        //     pintuAtas.SetBool("isOpen",false);
        //     pintuBawah.SetBool("isOpen",false);
        // }
    }

    void OnTriggerExit(){
        uiObj.SetActive(false);
        // anim.SetBool("open",false);
    }

}
