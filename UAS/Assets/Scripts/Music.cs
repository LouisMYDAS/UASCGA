using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public class Music : MonoBehaviour
{

    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio.Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey (KeyCode.M)){
            audio.mute = !audio.mute;
        }
        if (Input.GetKey (KeyCode.X)){
            audio.Stop();
        }
        if (Input.GetKey (KeyCode.P)){
            audio.Play();
        }
        if (Input.GetKey (KeyCode.Escape)){
             EditorSceneManager.LoadSceneAsyncInPlayMode("Assets/Scenes/Menu.unity", new UnityEngine.SceneManagement.LoadSceneParameters(LoadSceneMode.Single));
        }

    }
}
