using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    private List<Listener> listeners;

    private bool isGrounded = true;

    public bool IsGrounded
    {
        get
        {
            return isGrounded;
        }
    }

    private void Awake()
    {
        listeners = new List<Listener>();
    }

    public void AddListener(Listener listener)
    {
        listeners.Add(listener);
    }

    private void WarnListeners(Collectable.CollectableType type)
    {
        foreach (Listener listener in listeners)
        {
            listener.OnPlayerCollectedSomething(type);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);

        WarnListeners(collision.GetComponent<Collectable>().Type);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
                isGrounded = true;
                break;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
                isGrounded = false;
                break;
        }
    }
}
