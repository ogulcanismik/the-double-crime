using UnityEngine;

[CreateAssetMenu(fileName = "New NPC", menuName = "Scriptable Objects/NPCData")]
public class NPCSO : ScriptableObject {
    [Header("Info")]
    public string npcName;
    public Sprite portrait;
    public Sprite sprite;
    public RuntimeAnimatorController animatorController;
    
    public bool discovered;

    [Header("Stats")]
    [Range(-100, 100)]
    public int opinionValue;

    [Header("Dialogue")]
    public string inkKnotName;

}
