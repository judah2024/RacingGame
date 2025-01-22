using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMoveButton : MonoBehaviour
{
    public void OnLeftButtonDown()
    {
        GameManager.Instance.directionX = -1;
    }
    
    public void OnButtonUp()
    {
        GameManager.Instance.directionX = 0;
    }    
    
    public void OnRightButtonDown()
    {
        GameManager.Instance.directionX = 1;
    }
}
