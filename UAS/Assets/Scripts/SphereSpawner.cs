using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    public Transform tempatspawn;
    public GameObject objectspawn;
    public GameObject uiObj;
    // Start is called before the first frame update
    void Start()
    {
        uiObj.SetActive(false);
    }

    void OnTriggerStay(Collider other){
        uiObj.SetActive(true);
        if(other.gameObject.tag == "Player" && Input.GetKeyUp(KeyCode.E)){
            Instantiate(objectspawn, tempatspawn.position, tempatspawn.rotation);
        }
    }

    void OnTriggerExit(){
        uiObj.SetActive(false);
    }
}
