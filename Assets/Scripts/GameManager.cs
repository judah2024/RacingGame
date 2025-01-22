using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] GameObject playUI;
    [SerializeField] GameObject endUI;
    [SerializeField] TMP_Text gasText;
    
    [HideInInspector]
    public float directionX = 0;
    public bool IsPlaying { get; private set; }
    public float RoadSpeed { get; private set; }

    private int _gas = 0;
    
    private void Awake()
    {
        Instance = this;

        StartGame();
    }

    void StartGame()
    {
        playUI.SetActive(true);
        endUI.SetActive(false);

        IsPlaying = true;
        RoadSpeed = 1;
        _gas = 100;
        gasText.text = $"Gas : {_gas}";
        StartCoroutine(CoRemoveGas());
    }

    void EndGame()
    {
        IsPlaying = false;

        playUI.SetActive(false);
        endUI.SetActive(true);
    }

    IEnumerator CoRemoveGas()
    {
        while (true)
        {
            float t = 1 / RoadSpeed;
            yield return new WaitForSeconds(t);
            
            if (_gas <= 0)
            {
                EndGame();
                break;
            }

            _gas -= 1;

            gasText.text = $"Gas : {_gas}";
        }
    }

    public void OnReStartButtonClick()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void AddGas(int gas)
    {
        _gas += gas;
        gasText.text = $"Gas : {_gas}";
    }
    
}
