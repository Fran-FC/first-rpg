using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{
    [SerializeField]
    private Text count;
    [SerializeField]
    private Image countBackground;
    
    public void DisableCounter()
    {
        count.enabled = false;
        countBackground.enabled = false;
    }
    public void SetCount(int n){
        count.text = n.ToString();
    }
}
