using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(ReactiveTarget))]
public class WaneringAI : MonoBehaviour
{
    [SerializeField] private float speed = 3.0F;
    [SerializeField] private float obstacleRange = 5.0F;
    
    [SerializeField] private GameObject FireballPrefab;
    private GameObject _fireball;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ReactiveTarget obj = GetComponent<ReactiveTarget>();
        if (obj.IsUnityNull() || !obj.IsAlive()) return;
        
       transform.Translate(0, 0, speed * Time.deltaTime);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75F, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            PlayerCharacter player = hitObject.GetComponent<PlayerCharacter>();
            if (player.IsUnityNull())
            {
                if (hit.distance < obstacleRange)
                {
                    float angle = Random.Range(-110.0F, 110.0F);
                    transform.Rotate(0, angle, 0);
                }
            }
            else
            {
                if (_fireball.IsUnityNull())
                {
                    _fireball = Instantiate(FireballPrefab);
                    _fireball.transform.position =
                        transform.TransformPoint(Vector3.forward * 1.5F);
                    _fireball.transform.rotation = transform.rotation;
                    
                }
            }
            
           
        }
    }
}
