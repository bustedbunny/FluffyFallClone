using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager
{
    List<GameObject> activeBlockers;
    public float movementSpeed;
    private static readonly Quaternion[] rots = new Quaternion[] {
        Quaternion.Euler(0, 0, 0),
        Quaternion.Euler(0, 90, 0),
        Quaternion.Euler(0, 180, 0),
        Quaternion.Euler(0, -90, 0) };
    private static Vector3 spawnPos = new Vector3(0, -50, 0);
    public SpawnManager(float movSpeed)
    {
        activeBlockers = new();
        movementSpeed = movSpeed;
    }
    public void OnDisable()
    {
        foreach (GameObject obj in activeBlockers)
        {
            BlockerPool.ReturnToPool(obj);
        }
        activeBlockers.Clear();
    }
    public void Update()
    {
        for (int i = activeBlockers.Count - 1; i >= 0; i--)
        {
            GameObject blocker = activeBlockers[i];
            Vector3 pos = blocker.transform.position;
            pos.y += Time.deltaTime * movementSpeed;
            blocker.transform.position = pos;

            if (blocker.transform.position.y > 43)
            {
                activeBlockers.RemoveAt(i);
                BlockerPool.ReturnToPool(blocker);
            }
        }
    }
    public void Tick()
    {
        GameObject newBlocker = BlockerPool.MakeBlocker();
        activeBlockers.Add(newBlocker);
        newBlocker.transform.position = spawnPos;
        newBlocker.transform.rotation = rots[Random.Range(0, rots.Length)];
        newBlocker.GetComponent<Blocker>().movementSpeed = movementSpeed;
        newBlocker.SetActive(true);
    }
}
