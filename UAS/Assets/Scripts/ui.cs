using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class ui : MonoBehaviour
{
    protected Text d, t, o, p;
    protected string time, date;
    protected int oxy = 81, i = 0;
    
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

    void Start()
    {
        p = GameObject.Find("isPause").GetComponent<Text>();
        p.text = "";

        o = GameObject.Find("Oxy Per").GetComponent<Text>();

        StartCoroutine(OxyPercent());
    }

    void Update()
    {
        if(oxy == 0)
            StartCoroutine(GameOver());

        else{
            time = System.DateTime.UtcNow.ToLocalTime().ToString("HH:mm:ss");
            date = System.DateTime.UtcNow.ToLocalTime().ToString("dd MMMM yyyy");

            t = GameObject.Find("Time").GetComponent<Text>();
            t.text = time;

            d = GameObject.Find("Date").GetComponent<Text>();
            d.text = date;

            if(Input.GetKeyDown(KeyCode.Escape)){
                if(i == 1){
                    EditorApplication.isPaused = true;
                    p.text = "Game Paused";

                    i--;
                    Debug.Log("paused = " + i);
                }
                else {
                    EditorApplication.isPaused = false;
                    p.text = "Unpaused";

                    i++;
                    Debug.Log("un = " + i);
                }
            }

            // if(Input.GetKeyDown(KeyCode.Escape) && i == 1){
            //     UnityEditor.EditorApplication.isPaused = false;
            //     p.text = "";

            //     i--;
            // }
        }
    }
}
