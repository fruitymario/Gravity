using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTile : MonoBehaviour
{
    public virtual void OnTileEnter(BaseChar Character) { }
    public virtual void OnTileExit(BaseChar Character) { }
}
