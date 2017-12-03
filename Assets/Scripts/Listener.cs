using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listener : MonoBehaviour
{
    public virtual void OnPlayerCollectedSomething(Collectable.CollectableType t) { }
    public virtual void OnPlayerCollectedThreeLetters(Collectable.CollectableType t) { }
    public virtual void OnObaAnimation() { }
    public virtual void OnPlayerCollectedFourLetters() { }
    public virtual void OnErrouAnimation() { }
}
