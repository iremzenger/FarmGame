using UnityEngine;

public class InputHandler : MonoBehaviour
{

    private PlayerInputs playerInputs;

    private void Awake()
    {
        playerInputs=new PlayerInputs();
        playerInputs.Player.Enable();
    }

    public Vector2 GetMovementectorNormalized()
    {
        Vector2 inputVector = playerInputs.Player.Move.ReadValue<Vector2>();

        inputVector =inputVector.normalized;
        return inputVector;
    }
}
