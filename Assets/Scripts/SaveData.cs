using UnityEngine;

public abstract class SaveData
{
	public int Version { get; protected set; }

	public abstract SaveData VersionUp();
}

public class SaveDataV1 : SaveData
{
	public string PlayerName { get; set; } = "TEST";

	public SaveDataV1()
	{
		Version = 1;
	}

	public override SaveData VersionUp()
	{
		throw new System.NotImplementedException();
	}
}
