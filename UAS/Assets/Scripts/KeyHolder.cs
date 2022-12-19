using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    private List<Key.KeyType> keyList;
    public  GameObject ui;

    private void Awake(){
         ui.SetActive(false);
        keyList = new List<Key.KeyType>();

    }

    // private void Start(){
       
    // }

    public void AddKey(Key.KeyType keyType){
        Debug.Log("Add keyed: " + keyType);
        keyList.Add(keyType);
    }

    public void RemoveKey(Key.KeyType keyType){
        keyList.Remove(keyType);
    }

    public bool ContainsKey(Key.KeyType keyType){
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter(Collider collider){

        Key key = collider.GetComponent<Key>();
        if (key !=null){
            ui.SetActive(true);
             if(Input.GetKeyUp(KeyCode.E)){

                AddKey(key.GetKeyType());
                Destroy(key.gameObject);
                ui.SetActive(false);
            }
        }


        
        // if(key != null){
        //     AddKey(key.GetKeyType());
        //     Destroy(key.gameObject);
        // }
    }

    private void OnTriggerExit(Collider collider){
        Key key = collider.GetComponent<Key>();
        if(key != null){
        ui.SetActive(false);
        }

    }
}
