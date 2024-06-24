using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerBox : MonoBehaviour
{
    [field: SerializeField] public TMP_Text answerText { get; private set; }
    [field: SerializeField] public Image answerBoxImage { get; private set; }


    public void SendAnswer(int index)
    {
        if(GameManager.Instance.gameState == GameState.Ready)
        {
            GameManager.Instance.CheckAnswer(index);
        }
    }
    public void SetUpAnswer(string answer)
    {
        answerText.text = answer;
        answerText.color = ConfigsManager.Instance.gameplayConfig.defaultColorFont;
        answerBoxImage.color = ConfigsManager.Instance.gameplayConfig.defaultColorBox;
    }
    public void SetUpWrongAnswer()
    {
        answerText.color = ConfigsManager.Instance.gameplayConfig.wrongColorFont;
        answerBoxImage.color = ConfigsManager.Instance.gameplayConfig.wrongColorBox;
    }
    public void SetUpCorrectAnswer()
    {
        answerText.color = ConfigsManager.Instance.gameplayConfig.correctColorFont;
        answerBoxImage.color = ConfigsManager.Instance.gameplayConfig.correctColorBox;
    }
}
