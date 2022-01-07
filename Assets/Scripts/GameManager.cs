using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isActive;
    private SpawnManager spawnManager;
    [SerializeField] private GameObject environment;
    [SerializeField] private GameObject player;
    double prevTime = 0;
    public double interval;
    public double distance;
    public bool IsActive => isActive;
    public void StartGame()
    {
        isActive = true;
        distance = 0;
        environment.SetActive(true);
        player.SetActive(true);
    }
    public void StopGame()
    {
        isActive = false;
        spawnManager.OnDisable();
        environment.SetActive(false);
        player.SetActive(false);
    }
    private void Awake()
    {
        spawnManager = new(20);
        StopGame();
    }
    void Update()
    {
        if (!isActive)
        {
            return;
        }
        double curTime = Time.timeAsDouble;
        if (curTime - prevTime >= interval)
        {
            prevTime = curTime;
            spawnManager.Tick();
        }
        spawnManager.Update();
        distance += Time.deltaTime;
    }
}
