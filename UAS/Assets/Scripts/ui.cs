using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class ui : MonoBehaviour
{
    protected Text d, t;
    protected string time, date;
    protected int oxy = 81, j = 0;
    public static bool game_paused;
    public GameObject pause;
    
    // IEnumerator OxyPercent(){
    //     while (true){
    //         oxy -= 1;
    //         o.text = oxy.ToString() + "%";
    //         yield return new WaitForSeconds(5);
    //     }
    // }

    // private IEnumerator GameOver(){
    //     p.text = "You Died!";
    //     yield return new WaitForSeconds (2);
        
    //     p.text = ("Please Start a New Game!");
    //     yield return new WaitForSeconds (2);
        
    //     UnityEditor.EditorApplication.isPlaying = false;
    // }

    // void OnTriggerStay(Collider col){
    //     Debug.Log(col.gameObject.tag);

    //     if(col.gameObject.tag == "Untagged"){
    //         rt.SetActive(true);
            
    //         if(j == 0 || oxy < 100)
    //             ro.text = "Press E to \nRefill Oxygen";

    //         if(Input.GetKeyUp(KeyCode.E)){
    //             j = 1;
    //             oxy = 100;
    //             o.text = oxy.ToString() + "%";
    //             ro.text = "Oxygen Refilled!";
    //         }
    //     }
    // }

    // void OnTriggerExit(Collider col){
    //     rt.SetActive(false);
    //     ro.text = "";
    //     j = 0;
    // }

    void Start()
    {
        game_paused = false;
        pause.SetActive(false);
        // rt.SetActive(false);

        // o = GameObject.Find("Oxy Per").GetComponent<Text>();
        // p = GameObject.Find("Game Over").GetComponent<Text>();
        // p.text = "";
 
        // rt = GameObject.Find("TriggerOxy");
        // ro = GameObject.Find("OxyRefill").GetComponent<Text>();
        // ro.text = "";

        // StartCoroutine(OxyPercent());
    }

    void Update()
    {
        // if(oxy == 0)
        //     StartCoroutine(GameOver());

        // else{
            date = System.DateTime.UtcNow.ToLocalTime().ToString("dd MMMM yyyy");

            d = GameObject.Find("Date").GetComponent<Text>();
            d.text = date;

            if(Input.GetKeyDown(KeyCode.Escape)){
                if(!game_paused){
                    Time.timeScale = 0;
                    pause.SetActive(true);
                }
                else{
                    Time.timeScale = 1;
                    pause.SetActive(false);
                }
                game_paused = !game_paused;
            }
        // }
    }

    void FixedUpdate(){
        // if(oxy == 0)
        //     StartCoroutine(GameOver());
        // else{
            time = System.DateTime.UtcNow.ToLocalTime().ToString("HH:mm:ss");
            t = GameObject.Find("Time").GetComponent<Text>();
            t.text = time;
        }
    // }
}
