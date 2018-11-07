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
            GameObject spawn;

            if (spawnPool[i].activeSelf == false)
            {
                spawn = spawnPool[i];

                spawn.SetActive(true);
                spawn.transform.position = firePoint.position;
                spawn.transform.rotation = transform.parent.rotation;
                spawn.GetComponent<Rigidbody2D>().velocity = transform.right * spawn.GetComponent<Projectile>().vel;
                break;
            }
        }
    }

}
