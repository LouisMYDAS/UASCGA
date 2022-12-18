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
    public static bool game_paused;
    public GameObject pause;
    
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
        game_paused = false;
        pause.SetActive(false);

        o = GameObject.Find("Oxy Per").GetComponent<Text>();

        StartCoroutine(OxyPercent());
    }

    void Update()
    {
        if(oxy == 0)
            StartCoroutine(GameOver());

        else{
           
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

            // if(Input.GetKeyDown(KeyCode.Escape) && i == 1){
            //     UnityEditor.EditorApplication.isPaused = false;
            //     p.text = "";

            //     i--;
            // }
        }
    }

    void FixedUpdate(){
        if(oxy == 0)
            StartCoroutine(GameOver());
        else{
            time = System.DateTime.UtcNow.ToLocalTime().ToString("HH:mm:ss");
            t = GameObject.Find("Time").GetComponent<Text>();
            t.text = time;
        }
    }

    public void resume(){
        
    }
}
