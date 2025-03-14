using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control script / FPS Input")]
public class FPSInput : MonoBehaviour
{
    [SerializeField] private float speed = 6.0F;
    [SerializeField] private float gravity = 9.8F;
    
    CharacterController _characterController;
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical") * speed;
        //transform.Translate(horizontal * Time.deltaTime, 0, vertical * Time.deltaTime);
        
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = - gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _characterController.Move(movement);
        
    }
}
