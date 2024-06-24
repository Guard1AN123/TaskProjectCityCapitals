using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{

    public GameState gameState { get; private set; } = GameState.Loading;

    private int _roundCount = 0;
    private int _correctGuesses = 0;

    private int _currentCorrectIndex = 0;

    private List<Question> _questions;

    private void Start()
    {
        _roundCount = 0;
        _correctGuesses = 0;
        _questions = new List<Question>(ConfigsManager.Instance.questions);
    }
    public void InitializeGame()
    {
        gameState = GameState.Loading;
        UIManager.Instance.SetUpRound(_roundCount);
        UIManager.Instance.startGameObject.SetActive(false);
        GenerateQuestion();
    }
    public void GenerateQuestion()
    {
        var question = _questions[Random.Range(0, _questions.Count)];

        UIManager.Instance.gameplayQuestionText.text = question.question;

        var answers = question.GetQuestionAnswers();

        _currentCorrectIndex = answers.correctIndex;

        for (int i = 0; i < UIManager.Instance.answerBoxes.Count; i++)
        {
            UIManager.Instance.answerBoxes[i].SetUpAnswer(answers.answers[i]);
        }
        UIManager.Instance.gameplayParentGameObject.SetActive(true);
        _questions.Remove(question);
        UIManager.Instance.gameplayParentGameObject.transform.DOScale(Vector2.one, 0.5f).SetEase(Ease.InQuad).OnComplete(() => { gameState = GameState.Ready; });
    }
    public void CheckAnswer(int index)
    {
        gameState = GameState.Loading;
        if(index == _currentCorrectIndex)
        {
            UIManager.Instance.answerBoxes[_currentCorrectIndex].SetUpCorrectAnswer();
            AudioManager.Instance.PlayAudio(SoundType.Correct);
            _correctGuesses++;
        }
        else
        {
            UIManager.Instance.answerBoxes[_currentCorrectIndex].SetUpCorrectAnswer();
            UIManager.Instance.answerBoxes[index].SetUpWrongAnswer();
            AudioManager.Instance.PlayAudio(SoundType.Wrong);
        }
        _roundCount++;
        UIManager.Instance.SetUpRound(_roundCount);
        if(_roundCount == ConfigsManager.Instance.gameplayConfig.roundCount)
        {
            switch (_correctGuesses)
            {
                case 0:
                case 1:
                    UIManager.Instance.SetUpEndGame("terrible", ConfigsManager.Instance.gameplayConfig.endGameColorFontTerrible);
                    break;
                case 2:
                case 3:
                case 4:
                    UIManager.Instance.SetUpEndGame("good job", ConfigsManager.Instance.gameplayConfig.endGameColorFontGoodJob);
                    break;
                case 5:
                    UIManager.Instance.SetUpEndGame("great job", ConfigsManager.Instance.gameplayConfig.endGameColorFontGreatJob);
                    break;
            }
        }
        else
        {
            UIManager.Instance.gameplayParentGameObject.transform.DOScale(Vector2.zero, 0.5f).SetEase(Ease.OutQuad);
            Invoke("InitializeGame", 1f);
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

