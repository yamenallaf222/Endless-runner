using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Utilities;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void UpdateTextUI(TextMeshProUGUI textUIElement, string newText)
    {
        // Logic to show the score UI
        textUIElement.text = newText;
    }
}
