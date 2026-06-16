using System.Collections;
using System.Collections.Generic;
using Esper.ESave;
using UnityEngine;

public class SaveScript : MonoBehaviour {
    public const float LoadApplyDelay = 0.5f;

    private SaveFile saveFile;
    private List<ISaveable> saveables = new List<ISaveable>();

    void Awake() {
        saveFile = GetComponent<SaveFileSetup>().GetSaveFile();
        var found = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);
        foreach (var mb in found) {
            if (mb is ISaveable saveable) {
                saveables.Add(saveable);
            }
        }
    }

    public void Save() {
        foreach (var saveable in saveables) {
            saveable.OnSave(saveFile);
        }
        saveFile.Save();
    }

    public void Load() {
        StartCoroutine(LoadWithDelay(LoadApplyDelay));
    }

    public IEnumerator LoadWithDelay(float delay) {
        yield return new WaitForSeconds(delay);
        foreach (var saveable in saveables) {
            saveable.OnLoad(saveFile);
        }
    }
}
