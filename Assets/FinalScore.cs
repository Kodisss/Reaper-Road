using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
    public TextMeshProUGUI scoreDisplay;
    // Start is called before the first frame update
    void Start()
    {
        int score = GameManager.instance.score;
        string stext = score.ToString();
        while (stext.Length < 4)
        {
            stext = "0" + stext;
        }
        scoreDisplay.text = stext;
    }
}
