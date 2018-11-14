using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPool : MonoBehaviour {

    [Header("ObjectPool")]
    public List<GameObject> spawnPool = new List<GameObject>();
    private int spawnNum;

	public void Spawn(GameObject spawnObject, int spawnInt)
    {
        spawnNum = spawnInt;

        for (int i = 0; i < spawnNum; i++)
        {
            GameObject spawn = Instantiate(spawnObject, transform.position, Quaternion.identity);
            spawnPool.Add(spawn);
            spawn.SetActive(false);
        }
	}

    public void Fire(Transform firePoint)
    {
        for (int i = 0; i < spawnNum; i++)
        {
            if (spawnPool[i].activeSelf == false)
            {
                spawnPool[i].SetActive(true);
                spawnPool[i].transform.position = firePoint.position;
                spawnPool[i].transform.rotation = transform.parent.rotation;
                spawnPool[i].GetComponent<Rigidbody2D>().velocity = transform.right * spawnPool[i].GetComponent<Projectile>().vel;
                break;
            }
        }
    }

    public void FireDouble(Transform firePoint, Transform altFirePoint,  float fireDelay)
    {
        StartCoroutine(FireCor(firePoint, altFirePoint, fireDelay));
    }

    IEnumerator FireCor(Transform firePoint, Transform altFirePoint, float fireDelay)
    {
        Fire(firePoint);
        yield return new WaitForSeconds(fireDelay);
        Fire(altFirePoint);
        yield return new WaitForSeconds(fireDelay);
        yield return null;
    }

}
