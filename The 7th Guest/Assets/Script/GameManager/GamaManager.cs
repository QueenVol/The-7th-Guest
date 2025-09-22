using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GamaManager : MonoBehaviour
{
    public static event Action OnCheck;

    [SerializeField] private Snap snap;

    [SerializeField] private Sprite[] introSprites;
    [SerializeField] private Sprite[] recapSprites;
    private SpriteRenderer sr;
    private int introSprite = 0;
    private int recapSprite = 0;

    private bool canCheck = false;
    private bool canRecap = false;

    private int checkCount = 0;
    private int maxChecks = 10;

    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private TMP_Text averageText;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = introSprites[0];
        foreach (var drag in snap.draggableObj)
        {
            drag.canDrag = false;
        }
        canCheck = false;
        canRecap = false;

        if (endGamePanel != null)
        {
            endGamePanel.SetActive(false);
        }
    }

    private void Update()
    {
        NextSprite();
        if (canCheck)
        {
            CheckSatisfaction();
        }
        if (canRecap)
        {
            Recap();
        }
    }

    private void CheckSatisfaction()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (OnCheck != null)
            {
                OnCheck.Invoke();
            }
            checkCount++;

            if (checkCount >= maxChecks)
            {
                EndGame();
            }
        }
    }

    private void NextSprite()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (introSprites.Length == 0) return;
            introSprite++;
            if (introSprite < introSprites.Length)
            {
                sr.sprite = introSprites[introSprite];
            }
            else
            {
                sr.sprite = null;
                foreach (var drag in snap.draggableObj)
                {
                    drag.canDrag = true;
                }
                canCheck = true;
                canRecap = true;
            }
        }
    }

    private void Recap()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!canRecap)
            {
                recapSprite = 0;
                sr.sprite = recapSprites[recapSprite];
                canRecap = true;
                foreach (var drag in snap.draggableObj)
                {
                    drag.canDrag = false;
                }
                canCheck = false;
            }
            else
            {
                recapSprite++;

                if (recapSprite < recapSprites.Length)
                {
                    sr.sprite = recapSprites[recapSprite];
                }
                else
                {
                    sr.sprite = null;
                    canRecap = false;
                    recapSprite = 0;
                    foreach (var drag in snap.draggableObj)
                    {
                        drag.canDrag = true;
                    }
                    canCheck = true;
                }
            }
        }
    }
    private void EndGame()
    {
        foreach (var drag in snap.draggableObj)
        {
            drag.canDrag = false;
        }
        canCheck = false;
        canRecap = false;
        float totalSatisfaction = 0f;
        int count = 0;

        foreach (var drag in snap.draggableObj)
        {
            Neighbor neighbor = drag.GetComponent<Neighbor>();
            if (neighbor != null)
            {
                totalSatisfaction += neighbor.satisfication;
                count++;
            }
        }

        float averageSatisfaction;
        int average;
        if (count > 0)
        {
            averageSatisfaction = totalSatisfaction / count * 100f;
            average = Mathf.RoundToInt(averageSatisfaction);
        }
        else
        {
            average = 0;
        }

        if (endGamePanel != null && averageText != null)
        {
            endGamePanel.SetActive(true);
            averageText.text = "Your Score: " + average;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
