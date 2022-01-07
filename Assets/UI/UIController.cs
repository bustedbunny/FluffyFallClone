using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    public Button retryButton;
    public Label distanceLabel;
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        retryButton = root.Q<Button>("retry-button");
        retryButton.clicked += RetryButtonPressed;
        distanceLabel = root.Q<Label>("distance-label");
    }

    void RetryButtonPressed()
    {
        gameManager.StopGame();
        gameManager.StartGame();
    }

    private void FixedUpdate()
    {
        distanceLabel.text = Math.Round(gameManager.distance).ToString();
    }
}
