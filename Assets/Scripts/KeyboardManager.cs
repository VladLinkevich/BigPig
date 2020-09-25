using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardManager : MonoBehaviour
{
    [SerializeField] Joystick joystick;
    private void LateUpdate()
    {
        float vertical = joystick.Vertical;
        float horizontal = joystick.Horizontal;

        if (Input.GetKey(KeyCode.W) || vertical > 0.5f) { Messenger.Broadcast(GameEvent.UPMOVE); }
        else if (Input.GetKey(KeyCode.A) || horizontal < -0.5f) { Messenger.Broadcast(GameEvent.LEFTMOVE); }
        else if (Input.GetKey(KeyCode.D) || horizontal > 0.5f) { Messenger.Broadcast(GameEvent.RIGHTMOVE); }
        else if (Input.GetKey(KeyCode.S) || vertical < -0.5f) { Messenger.Broadcast(GameEvent.DOWNMOVE); }

        if (Input.GetKeyDown(KeyCode.Space)) { Messenger.Broadcast(GameEvent.REGUESTFORPLANTING); }
    }

    public void OnClickPlantingButton()
    {
        Messenger.Broadcast(GameEvent.REGUESTFORPLANTING);
    }
}
