using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTile : MonoBehaviour
{
    public abstract void OnTileEnter(BaseChar Character);
    public abstract void OnTileExit(BaseChar Character);
}
