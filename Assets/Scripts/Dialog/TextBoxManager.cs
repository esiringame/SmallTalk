﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TextBoxManager : MonoBehaviour {

    public Text theText;
    public TextAsset textFile;
    public Player player;
    private string[] textLines;
    public int currentLine;
    public int endAtLine;
    public bool isActive;

    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(false);
        if (textFile != null)
        {
            textLines = textFile.text.Split('\n');
        }
        endAtLine = textLines.Length;
    }

    public void talkTriggered(int enemyIndex)
    {
        gameObject.SetActive(true);
        isActive = true;
    }

    private void Update()
    {
        theText.text = textLines[currentLine];
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentLine++;
            if (currentLine == endAtLine)
            {
                gameObject.SetActive(false);
                isActive = false;
                player.onRelease();
            }
        }
    }
}
