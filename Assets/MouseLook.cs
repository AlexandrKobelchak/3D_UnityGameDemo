using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY,
        MouseX,
        MouseY
    }
    [SerializeField] RotationAxes axes = RotationAxes.MouseXAndY;
    
    [SerializeField] private float sensitivityHorz = 9.0F;
    [SerializeField] private float sensitivityVert = 9.0F;
    [SerializeField] private float minVertAngle = -45.0F;
    [SerializeField] private float maxVertAngle = 45.0F;
    
    private float _rotationX = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if(rigidbody != null) 
            rigidbody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0,  Input.GetAxis("Mouse X") * sensitivityHorz, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minVertAngle, maxVertAngle);
            
           float rotationY = transform.localEulerAngles.y;
           transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0.0f);
        }
        else //MouseXAndY
        {
             _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
             _rotationX = Mathf.Clamp(_rotationX, minVertAngle, maxVertAngle);
            
             float delta = Input.GetAxis("Mouse X") * sensitivityHorz;
             float rotationY = transform.localEulerAngles.y + delta;
                    
             transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0.0f);
        }
        
       
    }
}
