using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsScript : MonoBehaviour
{
    [SerializeField] KeyCode LeftDoorKey;
    [SerializeField] KeyCode RightDoorKey;
    [SerializeField] Animator _RightDoorAnimator;
    [SerializeField] Animator _LeftDoorAnimator;
    public static bool leftIsClosed = false;
    public static bool rightIsClosed = false;
    private void Awake()
    {
        leftIsClosed = false;
        rightIsClosed = false;
    }

    void Update()
    {
        _RightDoorAnimator.SetBool("RightClosed", rightIsClosed);
        _LeftDoorAnimator.SetBool("LeftClosed", leftIsClosed);
        if (Input.GetKeyDown(LeftDoorKey) && !leftIsClosed)
        {
            leftIsClosed= true;
        }
        else if(Input.GetKeyDown(RightDoorKey) && !rightIsClosed)
        {
            rightIsClosed = true;
        }
        else if (Input.GetKeyDown(LeftDoorKey) && leftIsClosed)
        {
            leftIsClosed = false;
        }
        else if (Input.GetKeyDown(RightDoorKey) && rightIsClosed)
        {
            rightIsClosed = false;
        }
    }
}
