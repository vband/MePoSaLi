using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesPanel : Listener
{
    [SerializeField]
    private RectTransform letterPrefab;
    [SerializeField]
    private PlayerCollisionController player;
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private Collectable.CollectableType type;

    private List<RectTransform> listOfLetters;
    private List<Listener> listeners;

    public void AddListener(Listener listener)
    {
        listeners.Add(listener);
    }

    private void WarnListeners_TreeLetters()
    {
        foreach (Listener l in listeners)
        {
            l.OnPlayerCollectedThreeLetters(type);
        }
    }

    private void WarnListeners_FourLetters()
    {
        foreach (Listener l in listeners)
        {
            l.OnPlayerCollectedFourLetters();
        }
    }

    private void Awake()
    {
        listeners = new List<Listener>();
    }

    private void Start()
    {
        listOfLetters = new List<RectTransform>();

        player.AddListener(this);
        gameManager.AddListener(this);
    }

    private void InstantiateLetter()
    {
        RectTransform instance = Instantiate(letterPrefab, transform);
        listOfLetters.Add(instance);
    }

    public override void OnPlayerCollectedSomething(Collectable.CollectableType t)
    {
        if (t == type)
        {
            InstantiateLetter();

            if (listOfLetters.Count == 3)
            {
                WarnListeners_TreeLetters();
            }

            else if (listOfLetters.Count == 4)
            {
                WarnListeners_FourLetters();
            }
        }
    }

    public override void OnObaAnimation()
    {
        foreach (RectTransform letter in listOfLetters)
        {
            Destroy(letter.gameObject);
        }
        listOfLetters.RemoveRange(0, listOfLetters.Count);
    }

    public override void OnErrouAnimation()
    {
        foreach (RectTransform letter in listOfLetters)
        {
            Destroy(letter.gameObject);
        }
        listOfLetters.RemoveRange(0, listOfLetters.Count);
    }
}
