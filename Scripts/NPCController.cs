using UnityEngine;

public class NPCController : MonoBehaviour {
    private const int DialogueSortOrder = 11;
    private const int DefaultSortOrder = 0;

    public NPCSO npcData;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public bool discovered;

    void Awake() {
        TryGetComponent(out spriteRenderer);
        TryGetComponent(out animator);
        spriteRenderer.sprite = npcData.sprite;
        animator.runtimeAnimatorController = npcData.animatorController;

        GetComponentInChildren<SpriteRenderer>().sprite = npcData.sprite;
        GetComponentInChildren<Animator>().runtimeAnimatorController = npcData.animatorController;
        discovered = npcData.discovered;
    }

    public void ApplyDialogueSortingOrder() {
        if (spriteRenderer != null) spriteRenderer.sortingOrder = DialogueSortOrder;
    }

    public void ResetSortingOrder() {
        if (spriteRenderer != null) spriteRenderer.sortingOrder = DefaultSortOrder;
    }
}
