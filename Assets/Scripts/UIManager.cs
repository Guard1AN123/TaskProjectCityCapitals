using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    [field: SerializeField] public List<AnswerBox> answerBoxes { get; private set; }
    [field: SerializeField] public TMP_Text gameplayQuestionText { get; private set; }
    [field: SerializeField] public TMP_Text gameplayRoundText { get; private set; }

    [field: SerializeField] public TMP_Text endgameStatusText { get; private set; }

    [field: SerializeField] public GameObject startGameObject { get; private set; }
    [field: SerializeField] public GameObject gameplayParentGameObject { get; private set; }
    [field: SerializeField] public GameObject endGameParentGameObject { get; private set; }



    public void SetUpRound(int currentRound)
    {
        gameplayRoundText.text = currentRound + "/" + ConfigsManager.Instance.gameplayConfig.roundCount;
    }
    public void SetUpEndGame(string endGameStatus, Color statusColor)
    {
        gameplayParentGameObject.SetActive(false);
        endGameParentGameObject.SetActive(true);

        endgameStatusText.text = endGameStatus;
        endgameStatusText.color = statusColor;
    }
}
