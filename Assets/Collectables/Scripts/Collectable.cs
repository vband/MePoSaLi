using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public enum CollectableType { Meme, Porn }

    [SerializeField]
    private CollectableType type;

    public CollectableType Type
    {
        get
        {
            return type;
        }

        set
        {
            type = value;
        }
    }
}
