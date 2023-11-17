using UnityEngine;

namespace Configs
{
    [CreateAssetMenu]
    public class GameConfig : ScriptableObject
    {
        [field: Header("Players")]
        [field: SerializeField, Range(0, 10)] public int MaxPlayers { get; private set; }
        [field: SerializeField, Range(0, 10)] public int MinPlayers { get; private set; }
        [field: SerializeField, Range(0, 1000)] public int Health { get; private set; }
        [field: SerializeField, Range(0, 1000)] public int Damage { get; private set; }
        [field: SerializeField, Range(0, 10)] public int PlayerSpeed { get; private set; }
        [field: SerializeField, Range(0, 100)] public int BulletSpeed { get; private set; }
    }
}