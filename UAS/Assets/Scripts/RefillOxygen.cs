using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefillOxygen : MonoBehaviour
{
    protected GameObject rt;
    protected Text o, p, ro;
    protected int oxy = 81, j = 0;
    
    IEnumerator OxyPercent(){
        while (true){
            oxy -= 1;
            o.text = oxy.ToString() + "%";
            yield return new WaitForSeconds(5);
        }
    }

    private IEnumerator GameOver(){
        p.text = "You Died!";
        yield return new WaitForSeconds (2);
        
        p.text = ("Please Start a New Game!");
        yield return new WaitForSeconds (2);
        
        UnityEditor.EditorApplication.isPlaying = false;
    }

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Player"){
            if(j == 0 || oxy < 100)
                ro.text = "Press E to \nRefill Oxygen";

            if(Input.GetKeyUp(KeyCode.E)){
                j = 1;
                oxy = 100;
                
                o.text = oxy.ToString() + "%";
                ro.text = "Oxygen Refilled!";
            }
        }
    }

    void OnTriggerExit(Collider col){
        ro.text = "";
        j = 0;
    }

    void Start()
    {
        o = GameObject.Find("Oxy Per").GetComponent<Text>();
        p = GameObject.Find("Game Over").GetComponent<Text>();
        p.text = "";

        ro = GameObject.Find("OxyRefill").GetComponent<Text>();
        ro.text = "";
        
        StartCoroutine(OxyPercent());
    }

    void Update()
    {
        if(oxy == 0){
            ro.text = "";
            StartCoroutine(GameOver());
        }
    }
}
