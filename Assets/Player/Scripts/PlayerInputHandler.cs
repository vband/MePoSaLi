using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private bool jumpTap, jumpHold;

    // Getters e Setters
    public bool JumpTap
    {
        get
        {
            return jumpTap;
        }

        set
        {
            jumpTap = value;
        }
    }
    public bool JumpHold
    {
        get
        {
            return jumpHold;
        }

        set
        {
            jumpHold = value;
        }
    }

    void Update ()
    {
        HandleInput();
	}

    private void HandleInput()
    {
        JumpTap = Input.GetMouseButtonDown(0);
        JumpHold = Input.GetMouseButton(0);
    }
}
