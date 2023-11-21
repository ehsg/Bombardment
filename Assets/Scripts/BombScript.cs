using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public float explosionDelay = 5f;
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExplosionCaroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private IEnumerator ExplosionCaroutine()
    {
        // wait
        yield return new WaitForSeconds(explosionDelay);

        //Explode
        Explode();
    }

    private void Explode()
    {
        //Create Explosion
        Instantiate(explosionPrefab, transform.position, explosionPrefab.transform.rotation);
        //Destroy Platforms

        //Destroy bomb
        Destroy(gameObject);
    }

}
