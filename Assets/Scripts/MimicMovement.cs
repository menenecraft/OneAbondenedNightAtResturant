using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicMovement : MonoBehaviour
{
    int Mimicstage = 0;
    Animator _MimicAnimator;
    [SerializeField, Range(2, 30)] float MimicwaitingTime = 8;
    [SerializeField, Range(0, 20)] int MimicAiSet;
    AudioSource _MimicAudio;
    [SerializeField] AudioSource Jumpscare;
    float MimicAI;
    bool AtDoor = false;
    private void Awake()
    {
        AtDoor = false;
        Mimicstage = 0;
        MimicAI = MimicAiSet;
        _MimicAnimator = GetComponent<Animator>();
        _MimicAudio = GetComponent<AudioSource>();
    }
    void MimicJumpscareHandler()
    {
        MainMenuManager.Jumpscare();
        _MimicAnimator.Play("MimicJumpscare");
    }
    void MimicCheckDoor()
    {
        if (DoorsScript.rightIsClosed)
        {
            AtDoor = false;
            Mimicstage = 0;
            StartCoroutine(MimicMovementCoroutine());
        }
        else
        {
            Jumpscare.Play();
            _MimicAnimator.Play("MimicJumpscare");
        }
    }
    private void Start()
    {
        StartCoroutine(MimicMovementCoroutine());
    }

    private void Update()
    {
        _MimicAnimator.SetFloat("Stage", Mimicstage);
        _MimicAnimator.SetBool("AtDoor", AtDoor);
    }

    IEnumerator MimicMovementCoroutine()
    {
        int randomAiNum = Random.Range(1, 21);
       
        if (randomAiNum <= MimicAI)
        {
            Mimicstage++;
            Debug.Log("Mimic at : " + Mimicstage);
        }
        if(Mimicstage >= 5)
        {
            AtDoor = true;
        }
        yield return new WaitForSeconds(MimicwaitingTime);
        StartCoroutine(MimicMovementCoroutine());
    }

    void stopAllCoroutines()
    {
        StopAllCoroutines();
    }
}
   
     

