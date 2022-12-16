using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchTrigger : MonoBehaviour
{
    public GameObject hatch;
    public GameObject uiObj;
    Animator anim;

    void Start()
    {
        uiObj.SetActive(false);
    }

    void Awake() 
    {
        GameObject gameObject = GameObject.Find("Hatch Door");
        anim = gameObject.GetComponent<Animator> ();
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
            anim.SetBool("open",true);
        }
        else if((Input.GetKeyUp(KeyCode.E)) == false){
            anim.SetBool("open",false);
        }
    }

    void OnTriggerExit(){
        uiObj.SetActive(false);
        anim.SetBool("open",false);
    }

}
