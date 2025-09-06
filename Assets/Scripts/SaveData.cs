using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class SaveData
{
	public int Version { get; protected set; }

	public abstract SaveData VersionUp();
}

[Serializable]
public class SaveDataV1 : SaveData
{
	public string PlayerName { get; set; } = "TEST";

	public SaveDataV1()
	{
		Version = 1;
	}

	public override SaveData VersionUp()
	{
		var saveData = new SaveDataV2();
		saveData.Name = PlayerName;
		saveData.Gold = 0;
		return saveData;
	}
}

[Serializable]
public class SaveDataV2 : SaveData
{
	public int Gold;
	public string Name { get; set; } = string.Empty;

	public SaveDataV2()
	{
		Version = 2;
	}

	public override SaveData VersionUp()
	{
		var saveData = new SaveDataV3();
		saveData.Gold = Gold;
		saveData.Name = Name;

		return saveData;
	}
}

[Serializable]
public class SaveDataV3 : SaveData
{
	public int Gold;
	public string Name { get; set; } = string.Empty;
	public List<SaveItemData> itemDatas = new List<SaveItemData>();

	public SaveDataV3()
	{
		Version = 3;
	}

	public override SaveData VersionUp()
	{
		throw new NotImplementedException();
	}
}