using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum InputKey
{
    Enter,
    BubbleStream,
    Right,
    Left,
    Up,
    Down,
    LaunchHunter
}

interface IInputControllerState
{
    public bool GetKeyDown(InputKey key);

    public int GetBubbleValue();

    public void Update();
}

class ArduinoControllerState : IInputControllerState
{
    public bool GetKeyDown(InputKey key)
    {
        switch (key)
        {
            case InputKey.Enter:
                return ArduinoInput.GetKey(ArduinoInputKey.StartEndButton);
            case InputKey.BubbleStream:
                return ArduinoInput.GetKey(ArduinoInputKey.BubbleStream);
            case InputKey.Right:
                return ArduinoInput.GetKey(ArduinoInputKey.JoystickXRight);
            case InputKey.Left:
                return ArduinoInput.GetKey(ArduinoInputKey.JoystickXLeft);
            case InputKey.Up:
                return ArduinoInput.GetKey(ArduinoInputKey.JoystickYUp);
            case InputKey.Down:
                return ArduinoInput.GetKey(ArduinoInputKey.JoystickYDown);
            case InputKey.LaunchHunter:
                return ArduinoInput.GetKey(ArduinoInputKey.LaunchHunter);
        }
        return false;
    }

    public int GetBubbleValue()
    {
        return 0;
    }

    public void Update()
    {
        ArduinoInput.GetInstance().Update();
    }
}

class KeyboardControllerState : IInputControllerState
{
    public bool GetKeyDown(InputKey key)
    {
        switch (key)
        {
            case InputKey.Enter:
                return Input.GetKeyDown(KeyCode.Return);
            case InputKey.BubbleStream:
                return Input.GetKey(KeyCode.B);
            case InputKey.Right:
                return Input.GetKeyDown(KeyCode.RightArrow);
            case InputKey.Left:
                return Input.GetKeyDown(KeyCode.LeftArrow);
            case InputKey.Up:
                return Input.GetKeyDown(KeyCode.UpArrow);
            case InputKey.Down:
                return Input.GetKeyDown(KeyCode.DownArrow);
            case InputKey.LaunchHunter:
                return Input.GetKeyDown(KeyCode.Space);
        }
        return false;
    }

    public int GetBubbleValue()
    {
        return 0;
    }

    public void Update()
    {
    }
}





public class InputController : MonoBehaviour
{
    static InputController Instance;
    IInputControllerState InputControllerState = new KeyboardControllerState();

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        if (ArduinoInput.GetInstance().ArduinoFound)
        {
            InputControllerState = new ArduinoControllerState();
        }
    }

    // Update is called once per frame
    void Update()
    {
        InputControllerState.Update();
    }

    public static bool GetKeyDown(InputKey key)
    {
        return Instance.InputControllerState.GetKeyDown(key);
    }

    public static int GetBubbleStreamValue()
    {
        return Instance.InputControllerState.GetBubbleValue();
    }
}
