using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ConfigsManager : MonoSingleton<ConfigsManager>
{
    [field: SerializeField] public GameplayConfig gameplayConfig { get; private set; }

    [field: SerializeField] public List<Question> questions { get; private set; }
}
