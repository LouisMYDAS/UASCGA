using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SitOn : MonoBehaviour
{
    public GameObject character;
    public GameObject anchor;
    bool isWalkingTowards = false;
    bool sittingOn = false;
    Animator anim;
    [SerializeField] CinemachineVirtualCamera vcam1; //3rd person
    [SerializeField] CinemachineVirtualCamera vcam2; //static person
        
    void Start()
    {
        vcam1.Priority = 1;
        vcam2.Priority = 0;
        anim = character.GetComponent<Animator>();
    }

    void Update()
    {
        /*if(anim.GetCurrentAnimatorStateInfo(0).IsName("SitDown")){
            drive.controlledBy = null;
        }*/
        if(isWalkingTowards){
            AutoWalkingTowards();
        }
    }

    void OnMouseDown(){
        if(!sittingOn){
            sittingOn = true;
            
            anim.SetBool("isWalking",true);
            anim.SetFloat("botSpeed",1f);
            isWalkingTowards = true;
            drive.controlledBy = this.gameObject;
            SwitchPriority();
        }else{
            sittingOn = false;
            StartCoroutine(StandUp());
        }
        
    }

     IEnumerator StandUp()
     {
        anim.SetBool("isSitting",false);
        sittingOn = false;
        isWalkingTowards = false;
        SwitchPriority();
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length+anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        drive.controlledBy = null;
     }

    void AutoWalkingTowards(){
        Vector3 targetDir;
        targetDir = new Vector3(anchor.transform.position.x - character.transform.position.x, 0f,anchor.transform.position.z - character.transform.position.z);
        Quaternion rot = Quaternion.LookRotation(targetDir);
        character.transform.rotation = Quaternion.Slerp(character.transform.rotation,rot,0.05f);

        if(Vector3.Distance(character.transform.position, anchor.transform.position) < 0.8f){
            anim.SetBool("isSitting",true);
            anim.SetBool("isWalking",false);
            character.transform.rotation = anchor.transform.rotation;
            isWalkingTowards = false;
            sittingOn = true;
        }
    }

    void FixedUpdate(){
        AnimLerp();
    }

    void AnimLerp(){
        if(!sittingOn) return;
        if(Vector3.Distance(character.transform.position, anchor.transform.position) > 0.1f){
            character.transform.rotation = Quaternion.Lerp(character.transform.rotation,anchor.transform.rotation,Time.deltaTime * 0.5f);
            character.transform.position = Vector3.Lerp(character.transform.position,anchor.transform.position,Time.deltaTime * 0.5f);
        }else{
            character.transform.position = anchor.transform.position;
            character.transform.rotation = anchor.transform.rotation;
        }
    }

    private void SwitchPriority(){
        if(sittingOn){
            vcam1.Priority = 0;
            vcam2.Priority = 1;
        }else{
            vcam1.Priority = 1;
            vcam2.Priority = 0;
        }
    }
}
