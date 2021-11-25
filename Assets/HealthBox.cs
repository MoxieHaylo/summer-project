using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            StartCoroutine("SelfDestruct");
        }
    }

    IEnumerator SelfDestruct()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Destroy(this.gameObject);
            yield break;
        }
    }
}
