using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicBoxSystem : MonoBehaviour
{
    int BoxValue = 100;
    [SerializeField] float TimeUntilDecrease;
    [SerializeField] Slider _slider;
    [SerializeField] int DecreaseAmount = 3;
    [SerializeField] Animator _EndoAnimator;
    bool CanKill = false;
    private void Awake()
    {
        BoxValue = 100;
        CanKill = false;
    }
    void Start()
    {
        StartCoroutine(BoxGoDown());
    }
    private void Update()
    {
        _slider.value = BoxValue;
    }
    IEnumerator BoxGoDown()
    {
        Debug.Log(BoxValue);
        yield return new WaitForSeconds(TimeUntilDecrease);
        if(BoxValue > 0)
        {
            WindDown();
        }
        else
        {
            _EndoAnimator.SetBool("CanKill", CanKill);
            CanKill= true;
        }
        StartCoroutine(BoxGoDown());
    }

   public void WindUp()
    {
        if(BoxValue < 100)
        {
            BoxValue++;
        }
    }
    void WindDown()
    {
        BoxValue -= DecreaseAmount;
    }

}
