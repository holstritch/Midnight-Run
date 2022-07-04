using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class PlaceholderController : MonoBehaviour
{
    public float movementPower = 2;
    public float jumpPower = 20;
    public LayerMask floorMask;

    public Animator anim;

    Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void FixedUpdate()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 camForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 camRight = Vector3.Scale(Camera.main.transform.right, new Vector3(1, 0, 1)).normalized;

        Vector3 movement = (camRight * input.x) + (camForward * input.y);
        body.AddForce(movement * movementPower);

        Vector3 lateralMovement = Vector3.Scale(body.velocity, new Vector3(1, 0, 1));
        if (lateralMovement.magnitude > 2)
        {
            anim.SetBool("IsWalking", true);
            transform.forward = lateralMovement;
            
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
    }
}
    


