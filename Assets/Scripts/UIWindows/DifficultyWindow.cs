using UnityEngine;
using UnityEngine.UI;

public class DifficultyWindow : GenericWindow
{
	private int index;

	public ToggleGroup toggleGroup;
	public Toggle[] toggles;

	public override void Open()
	{
		base.Open();

		var data = SaveLoadManager.Data;
		index = data.Difficulty;

		toggles[index].isOn = true;
	}

	public override void Close()
	{
		base.Close();

		SaveLoadManager.Data.Difficulty = index;
		SaveLoadManager.Save();
	}

	//private void OnDisable()
	//{
	//	SaveLoadManager.Data.Difficulty = index;
	//	SaveLoadManager.Save();
	//}

	public void OnClickEasy(bool value)
	{
		if(value)
		{
			Debug.Log("OnClickEasy");
			index = 0;
		}
	}
	public void OnClickNormal(bool value)
	{
		if (value)
		{
			Debug.Log("OnClickNormal");
			index = 1;
		}
	}
	public void OnClickHard(bool value)
	{
		if (value)
		{
			Debug.Log("OnClickHard");
			index = 2;
		}
	}

	public void OnClickBack()
	{
		manager.Open(Windows.Start);
	}
}
