using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UIManager;

public class ScoreUI : MonoBehaviour
{

    [SerializeField]
    private UIManager manager = null;

    private TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = "0";
    }

    public void incrementScore()
    {

        int score = int.Parse(scoreText.text) + 1;

        // Logic to update the score UI
        if (manager != null && scoreText != null)
        {
            manager.UpdateTextUI(scoreText, score.ToString());
        }
        else
        {
            Debug.LogError("Manager or Score Text is not assigned.");
        }
    }
}
