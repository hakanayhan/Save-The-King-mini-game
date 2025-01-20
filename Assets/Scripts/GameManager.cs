using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isGameOn = true;

    [SerializeField] private WaterEmitter waterEmitter;

    [SerializeField] private GameObject winTab;
    [SerializeField] private GameObject loseTab;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    public void Win()
    {
        if (isGameOn)
        {
            isGameOn = false;
            winTab.SetActive(true);
        }
    }
    public void Lose()
    {
        if (isGameOn)
        {
            isGameOn = false;
            loseTab.SetActive(true);
        }
    }
    
}
