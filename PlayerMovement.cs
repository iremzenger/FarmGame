using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private InputHandler inputHandler;
    private Rigidbody rb;

    private void Awake()
    {
        inputHandler = GetComponent<InputHandler>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector2 inputVector = inputHandler.GetMovementectorNormalized();
        Vector3 movement = new Vector3(inputVector.x, 0, inputVector.y) * moveSpeed;

        // Hareketi Rigidbody.velocity ile uygula
        rb.linearVelocity = movement;

        // Veya force ile (daha fiziksel)
        // rb.AddForce(movement, ForceMode.Force);

        //Debug.Log("Hareket Vekt�r�: " + movement);
    }
    //void Update()
    //{
    //    // Input de�erlerini kontrol
    //    Vector2 input = inputHandler.GetMovementectorNormalized();
    //    Debug.Log("Input De�eri: " + input);

    //    // H�z de�erini kontrol
    //    Debug.Log("Mevcut H�z: " + rb.linearVelocity);

    //    // Pozisyon de�i�imini kontrol
    //    Debug.Log("Pozisyon: " + transform.position);
    //}
}
