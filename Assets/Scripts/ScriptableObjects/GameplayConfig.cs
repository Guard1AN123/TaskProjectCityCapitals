using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameplayConfig", menuName = "QuestionGame/GameplayConfig")]
public class GameplayConfig : ScriptableObject
{
    [field: SerializeField] public int roundCount { get; private set; }


    [field: SerializeField] public Color correctColorBox { get; private set; }
    [field: SerializeField] public Color correctColorFont { get; private set; }
    [field: SerializeField] public Color wrongColorBox { get; private set; }
    [field: SerializeField] public Color wrongColorFont { get; private set; }
    [field: SerializeField] public Color defaultColorBox { get; private set; }
    [field: SerializeField] public Color defaultColorFont { get; private set; }

    [field: SerializeField] public Color endGameColorFontTerrible { get; private set; }
    [field: SerializeField] public Color endGameColorFontGoodJob { get; private set; }
    [field: SerializeField] public Color endGameColorFontGreatJob { get; private set; }
}
