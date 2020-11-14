using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameOverseer : MonoBehaviour
{
    #region static variables
    private static MainGameOverseer instance;

    public static MainGameOverseer Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<MainGameOverseer>();
            }
            return instance;
        }
    }
    #endregion static variables

    private void Awake()
    {

    }
}
