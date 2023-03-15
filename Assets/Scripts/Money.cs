using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    private void Update()
    {
        moneyText.text = "$ " + Player.Money.ToString();
    }
}
