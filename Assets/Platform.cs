using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public  GameObject  gameObject;

            Collider    collider;
            Collider    parCol;
            Renderer    rend;
            Renderer    parRend;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
        rend = GetComponent<Renderer>();
        parCol = this.transform.parent.GetComponent<Collider>();
        parRend = this.transform.parent.GetComponent<Renderer>();
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
        //Destroy(gameObject);
        collider.enabled = !collider.enabled;
        rend.enabled = !rend.enabled;
        parCol.enabled = !parCol.enabled;
        parRend.enabled = !parRend.enabled;
        yield return new WaitForSeconds(5);
        collider.enabled = collider.enabled = true;
        rend.enabled = rend.enabled = true;
        parCol.enabled = parCol.enabled = true;
        parRend.enabled = parRend.enabled=true;
        yield break;
    }
}
