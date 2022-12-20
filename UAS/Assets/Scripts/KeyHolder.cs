using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    private List<Key.KeyType> keyList;
    public  GameObject ui;
    public GameObject uiDenied;

    public GameObject uiGranted;
    public Light lampu;

    private void Awake(){
         GameObject gameObject = GameObject.Find("Point Light Tanda");
         lampu = gameObject.GetComponent<Light> ();
         ui.SetActive(false);
         uiDenied.SetActive(false);
         uiGranted.SetActive(false);
        keyList = new List<Key.KeyType>();
       

    }

    // private void Start(){
       
    // }

    public void AddKey(Key.KeyType keyType){
        keyList.Add(keyType);
    }

    public void RemoveKey(Key.KeyType keyType){
        keyList.Remove(keyType);
    }

    public bool ContainsKey(Key.KeyType keyType){
        return keyList.Contains(keyType);
    }

    private void OnTriggerStay(Collider collider){

        Key key = collider.GetComponent<Key>();
        if (key !=null){
            ui.SetActive(true);
             if(Input.GetKeyUp(KeyCode.E)){

                AddKey(key.GetKeyType());
                Destroy(key.gameObject);
                ui.SetActive(false);
            }
        }

        doorLobbyRoom dlr = collider.GetComponent<doorLobbyRoom>();
        if(dlr != null){
            if(Input.GetKeyUp(KeyCode.E)){
                if(ContainsKey(dlr.GetKeyType())){
                    RemoveKey(dlr.GetKeyType());

                    dlr.OpenDoor();
                    lampu.color  = Color.green;
                    Destroy(dlr.gameObject);
                    StartCoroutine(AccessGranted());

                }
                else{
                    uiDenied.SetActive(true);
                }
            }
            
        }
        
    }

    private IEnumerator AccessGranted()
    {
        uiGranted.SetActive(true);
        yield return new WaitForSeconds(3);
        uiGranted.SetActive(false);
    }

    private void OnTriggerExit(Collider collider){
        Key key = collider.GetComponent<Key>();
        if(key != null){
            ui.SetActive(false);
        }
        uiDenied.SetActive(false);
        uiGranted.SetActive(false);

    }
}
