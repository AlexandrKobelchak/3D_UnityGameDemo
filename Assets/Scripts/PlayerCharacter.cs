using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hurt(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            health = 100.0F;
            Debug.Log("PLAYER DIED !!!");
        }
    }
}
