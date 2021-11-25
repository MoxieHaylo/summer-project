using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject gameObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            print("Occupied");
            StartCoroutine("PlatformDecay");
        }
    }
    
    //work out way to move through platforms

    IEnumerator PlatformDecay()
    {
        //play animation of plaform fracturing
        //play sound
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
        yield break;
    }
}
