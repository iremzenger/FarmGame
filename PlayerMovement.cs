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

        //Debug.Log("Hareket Vektörü: " + movement);
    }
    //void Update()
    //{
    //    // Input deðerlerini kontrol
    //    Vector2 input = inputHandler.GetMovementectorNormalized();
    //    Debug.Log("Input Deðeri: " + input);

    //    // Hýz deðerini kontrol
    //    Debug.Log("Mevcut Hýz: " + rb.linearVelocity);

    //    // Pozisyon deðiþimini kontrol
    //    Debug.Log("Pozisyon: " + transform.position);
    //}
}
