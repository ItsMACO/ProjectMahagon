using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Player player;
    [SerializeField] float timeToDestroy = 2f;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        StartCoroutine(DestroyAfterTime(timeToDestroy));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DestroyAfterTime(float timeUntilObjectDestroyed)
    {
        yield return new WaitForSeconds(timeUntilObjectDestroyed);
        Destroy(gameObject);
    }
}
