using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    public TextMeshProUGUI scoretxt;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateDisplay", 0f, 0.5f);
    }

    private void UpdateDisplay()
    {
        int score = GameManager.instance.score;
        string stext = score.ToString();
        while (stext.Length < 4)
        {
            stext = "0" + stext;
        }
        scoretxt.text = stext;
    }
}
