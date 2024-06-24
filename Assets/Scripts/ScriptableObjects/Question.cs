using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "QuestionGame/Question")]
public class Question : ScriptableObject
{
    [field: SerializeField, Multiline] public string question { get; private set; }

    [field: SerializeField] public string answer { get; private set; }
    [field: SerializeField] public List<string> fillerAnswers { get; private set; }



    public (List<string> answers, int correctIndex) GetQuestionAnswers()
    {
        List<string> temp = new List<string>(fillerAnswers);
        while (temp.Count > 3)
        {
            temp.RemoveAt(Random.Range(0,temp.Count));
        }
        int insertIndex = Random.Range(0, 4);
        temp.Insert(insertIndex, answer);
        return new(temp, insertIndex);
    }

}
