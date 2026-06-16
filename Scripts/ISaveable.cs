using Esper.ESave;

public interface ISaveable {
    void OnSave(SaveFile saveFile);
    void OnLoad(SaveFile saveFile);
}
