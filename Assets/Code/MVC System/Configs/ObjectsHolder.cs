using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = nameof(ObjectsHolder), menuName = "GameConfigs/" + nameof(ObjectsHolder))]
    public class ObjectsHolder : ScriptableObject
    {
        [field: Header("Prefabs")]
        [field: SerializeField] public GameObject Player { get; private set; }
        [field: SerializeField] public GameObject Bullet { get; private set; }
        [field: SerializeField] public GameObject Coin { get; private set; }
    }
}