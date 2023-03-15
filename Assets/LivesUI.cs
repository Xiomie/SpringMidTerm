using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI LivesText;
   void Update()
    {
        LivesText.text = Player.Lives.ToString() + " LIVES";
    }
}
