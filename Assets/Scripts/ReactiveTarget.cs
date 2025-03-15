using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    [SerializeField] private int lifeLevel = 100;
    
    public int ReactToHit(int damage)//return LifeLevel
    {
        lifeLevel -= damage;
        if (lifeLevel <= 0)
        {
            this.transform.Rotate(-90.0F, 0, 0);
            this.transform.Translate(0, 0, -1.4F);
            StartCoroutine(Die());
        }
        return lifeLevel;
    }

    public bool IsAlive()
    {
        return lifeLevel > 0;
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
