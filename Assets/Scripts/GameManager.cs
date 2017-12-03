using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Listener
{
    [SerializeField]
    private CollectablesPanel MsPanel, PsPanel;

    private Animator anim;

    private bool playerCollectedTheeMs, playerCollectedThreePs;
    private List<Listener> listeners;

    public void AddListener(Listener listener)
    {
        listeners.Add(listener);
    }

    private void Awake()
    {
        listeners = new List<Listener>();
    }

    void Start ()
    {
        MsPanel.AddListener(this);
        PsPanel.AddListener(this);
        playerCollectedTheeMs = false;
        playerCollectedThreePs = false;

        anim = GetComponent<Animator>();
	}

    private void Update()
    {
        if (playerCollectedThreePs && playerCollectedTheeMs)
        {
            anim.SetTrigger("Oba");
            playerCollectedTheeMs = false;
            playerCollectedThreePs = false;
            WarnListeners_ObaAnimation();
        }
    }

    private void WarnListeners_ObaAnimation()
    {
        foreach (Listener l in listeners)
        {
            l.OnObaAnimation();
        }
    }

    private void WarnListeners_ErrouAnimation()
    {
        foreach (Listener l in listeners)
        {
            l.OnErrouAnimation();
        }
    }

    public override void OnPlayerCollectedThreeLetters(Collectable.CollectableType t)
    {
        switch (t)
        {
            case Collectable.CollectableType.Meme:
                playerCollectedTheeMs = true;
                break;
            case Collectable.CollectableType.Porn:
                playerCollectedThreePs = true;
                break;
        }
    }

    public override void OnPlayerCollectedFourLetters()
    {
        anim.SetTrigger("Errou");
        playerCollectedTheeMs = false;
        playerCollectedThreePs = false;
        WarnListeners_ErrouAnimation();
    }
}
