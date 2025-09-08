using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;
using SaveDataVC = SaveDataV4;

public class SaveLoadManager
{
    public static int SaveDataVersion { get; } = 4;

    static SaveLoadManager()
    {
        Load();
    }

    public static SaveDataVC Data { get; set; } = new SaveDataVC();

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
        TypeNameHandling = TypeNameHandling.All,
    };

    public static bool Save(int slot = 0)
    {
        if (Data == null || slot < 0 || slot >= SaveFileName.Length)
            return false;

        try
        {
            if (!Directory.Exists(SaveDirectory))
            {
                Directory.CreateDirectory(SaveDirectory);
            }

            var path = Path.Combine(SaveDirectory, SaveFileName[slot]);
            var json = JsonConvert.SerializeObject(Data,settings);

            // ��ȣȭ ���� �ʿ�
            // byte ��ȯ, ����, ��ȣȭ

            File.WriteAllText(path, json);

            return true;
        }
        catch
        {
            Debug.Log("Save ���� �߻�");
            return false;
        }
    }

    public static bool Load(int slot = 0)
    {
        if (slot < 0 || slot >= SaveFileName.Length)
            return false;

        var path = Path.Combine(SaveDirectory, SaveFileName[slot]);

        if(!File.Exists(path))
            return false;

        try
        {
            var json = File.ReadAllText(path);
            var saveData = JsonConvert.DeserializeObject<SaveData>(json, settings);
			//Data = JsonConvert.DeserializeObject<SaveDataVC>(json, settings);

            // ��ȣȭ ���� �ʿ�
            // ��ȣȭ, ��������, string ��ȯ

			while (saveData.Version < SaveDataVersion)
            {
                saveData = saveData.VersionUp();
            }

			Data = saveData as SaveDataVC;
            return true;
		}
        catch
        {
            Debug.Log("Load ���� �߻�");
            return false;
        }
    }
}
