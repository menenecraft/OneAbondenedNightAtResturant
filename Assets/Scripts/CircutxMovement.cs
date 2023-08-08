using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class CircutxMovement : MonoBehaviour
{
    int Endostage = 0;
    Animator _endoAnimator;
    [SerializeField, Range(2, 30)] float EndowaitingTime = 8;
    [SerializeField, Range(0, 20)] int EndoAiSet;
    AudioSource _endoAudio;
    [SerializeField] AudioSource Jumpscare;
    float EndoAI;
    bool AtDoor;
    private void Awake()
    {
        Endostage = 0;
        EndoAI = EndoAiSet; 
        _endoAnimator = GetComponent<Animator>();
        _endoAudio = GetComponent<AudioSource>();
    }
    private void Start()
    {
      StartCoroutine(endoMovement());
    }

    private void Update()
    {
        _endoAnimator.SetBool("AtDoor", AtDoor);
        _endoAnimator.SetFloat("Stage", Endostage);
        if(Endostage >= 5)
        {
            AtDoor = true;
        }
        else
        {
            AtDoor = false;
        }
    }

    IEnumerator endoMovement()
    {
        int randomAiNum = Random.Range(1, 21);
        if (Endostage >= 5)
        {
            AtDoor = true;
        }
        if (randomAiNum <= EndoAI)
        {
            Endostage++;
            Debug.Log(Endostage);
            _endoAudio.PlayDelayed(0.3f);
        }
        switch (Endostage)
        {
            case 2:
                int randomnum = Random.Range(1, 5);
                {
                    if (randomnum > 3)
                    {
                        Endostage = 3;
                    }
                    if (randomnum == 3)
                    {
                        Endostage = 2;
                    }

                    else
                    {
                        Endostage = 4;
                    }
                    break;
                }
            case 3:
                {
                    int randomnum2 = Random.Range(1, 5);

                    if (randomnum2 < 3)
                    {
                        Endostage = 3;
                    }
                    if (randomnum2 == 3)
                    {
                        Endostage = 4;
                    }
                    else
                    {
                        Endostage = 1;
                    }
                    break;
                }
            case 1:
                int randomAiNum3 = Random.Range(1, 6);
                if (randomAiNum3 < 2)
                {
                    Endostage = 2;
                }
                else if (randomAiNum3 == 3)
                {
                    Endostage = 4;
                }
                else
                {
                    Endostage = 3;
                }
                break;
        }
        yield return new WaitForSeconds(EndowaitingTime);
        StartCoroutine(endoMovement());
    }


    void CircuitXJumpscareHandler()
    {
        MainMenuManager.Jumpscare();
    }
    void checkTheDoor()
    {
        if (DoorsScript.leftIsClosed)
        {
            Endostage = 0;
            StartCoroutine(endoMovement());
        }
        else
        {
            Jumpscare.Play();
            _endoAnimator.Play("EndoJumpscare");
        }
    }
    void stopAllCoroutines()
    {
        StopAllCoroutines();
    }

}
