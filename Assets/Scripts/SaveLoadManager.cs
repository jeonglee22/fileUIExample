using Newtonsoft.Json;
using System.IO;
using UnityEngine;

public class SaveLoadManager
{
    public static int SaveDataVersion { get; } = 1;

    public static SaveDataV1 Data {  get; set; }

    public static readonly string[] SaveFileName =
    {
        "SaveAuto.json",
        "Save1.json",
        "Save2.json",
        "Save3.json",
    };

    public static string SaveDirectory => $"{Application.persistentDataPath}/Save";

    private static JsonSerializerSettings settings = new JsonSerializerSettings()
    {
        Formatting = Formatting.Indented,
        TypeNameHandling = TypeNameHandling.Auto,
    };

    public static bool Save(int slot = 0)
    {
        if (Data == null || slot < 0 || slot >= SaveFileName.Length)
            return false;

        if (!Directory.Exists(SaveDirectory))
        {
            Directory.CreateDirectory(SaveDirectory);
        }

        var path = Path.Combine(SaveDirectory, SaveFileName[slot]);
        var json = JsonConvert.SerializeObject(Data,settings);
        File.WriteAllText(path, json);

        return true;
    }

    public static bool Load(int slot = 0)
    {
        if (slot < 0 || slot >= SaveFileName.Length)
            return false;

        var path = Path.Combine(SaveDirectory, SaveFileName[slot]);

        if(!File.Exists(path))
            return false;

        var json = File.ReadAllText(path);
        //var saveData = JsonConvert.DeserializeObject<SaveData>(json, settings);
        Data = JsonConvert.DeserializeObject<SaveDataV1>(json, settings);


    
        //Data = saveData as SaveDataV1;
        
		return true;
    }
}
