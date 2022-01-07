using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class BlockerPool
{
    public enum BlockerRequest
    {
        Any,
        BlockerCross,
        BlockerHole,
        BlockerSideHole,
        BlockerSideStep
    }
    public static string[] names =
    {
            "BlockerCross",
            "BlockerHole",
            "BlockerSideHole",
            "BlockerSideStep"
        };

    static readonly GameObject[] prefabs = Resources.LoadAll<GameObject>("Prefabs");

    static readonly List<GameObject> freeObjects = new();

    public static void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        freeObjects.Add(obj);
    }

    public static GameObject MakeBlocker(BlockerRequest request = BlockerRequest.Any)
    {
        int ind = ((int)request == 0) ? UnityEngine.Random.Range(0, prefabs.Length) : (int)request - 1;
        GameObject newObj = freeObjects.FirstOrDefault(x => x.name == (names[(int)ind]) + "(Clone)");
        if (newObj != null)
        {
            freeObjects.Remove(newObj);
            return newObj;
        }
        return GameObject.Instantiate(prefabs[ind]);
    }
}
