using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    [SerializeField] private int lifeLevel = 100;
    private bool isAlive = true;
    
    public int ReactToHit(int damage)//return LifeLevel
    {
        lifeLevel -= damage;
        if (isAlive && lifeLevel <= 0)
        {
            isAlive = false;

            this.transform.Rotate(-90.0F, 0, 0);
            this.transform.Translate(0, 0, -1.4F);
            StartCoroutine(Die());

        }

        return lifeLevel < 0 ? 0 : lifeLevel;
    }

    public bool IsAlive()
    {
        return isAlive;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Die()
    {
        
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}
