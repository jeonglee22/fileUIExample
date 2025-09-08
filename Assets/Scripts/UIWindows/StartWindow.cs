using UnityEngine;
using UnityEngine.UI;

public class StartWindow : GenericWindow
{
    public bool canContinue = true;

    public Button continueButton;
    public Button newGameButton;
    public Button optionButton;

	protected void Awake()
	{
		continueButton.onClick.AddListener(OnClickContinue);
		newGameButton.onClick.AddListener(OnClickNewGame);
		optionButton.onClick.AddListener(OnClickOption);
	}

	public override void Open()
	{
		continueButton.gameObject.SetActive(canContinue);
		// active관련 프로퍼티 - activeSelf, activeInHierarchy
		firstSelected = continueButton.gameObject.activeSelf ? continueButton.gameObject : newGameButton.gameObject;

		base.Open();
	}

	public void OnClickContinue()
    {
		Debug.Log("OnClickContinue");
		manager.Open(Windows.Difficulty);
	}

	public void OnClickNewGame()
	{
		Debug.Log("OnClickNewGame");
		manager.Open(Windows.Difficulty);
	}

	public void OnClickOption()
	{
		Debug.Log("OnClickOption");
	}
}
