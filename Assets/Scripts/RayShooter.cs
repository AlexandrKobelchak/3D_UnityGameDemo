using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class RayShooter : MonoBehaviour
{
    [SerializeField] GUIStyle Style = new GUIStyle();
    private Camera _camera;
    
    // Start is called before the first frame update
    void Start()
    {
        
        _camera = GetComponent<Camera>();
        //if (!Debug.isDebugBuild)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2.0F, _camera.pixelHeight / 2.0F, 0.0f);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            { 
                //Debug.Log($"X = {hit.point.x}  Y = {hit.point.y}  Z = {hit.point.z}");
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
              
                if (target != null)
                {
                    target.ReactToHit(20);
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point, 2.0F));
                }
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 position, float radius)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(radius, radius, radius);
        sphere.transform.position = position;
        
        yield return new WaitForSeconds(1.05f);
        Destroy(sphere);
        
    }
    
    
    private void OnGUI()
    {
        int size = 20;
        float posX = Screen.width * 0.5f - size * 0.5f;
        float posY = Screen.height * 0.5f - size * 0.5f;
        GUI.Label(new Rect(posX, posY, size, size), "+", Style);
    }
}
