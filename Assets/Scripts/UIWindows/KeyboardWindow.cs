using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardWindow : GenericWindow
{
	public TextMeshProUGUI nameText;

	public Button cancelButton;
	public Button deleteButton;
	public Button acceptButton;

	public Button[] alphabetButton;

	private bool IsCursorOn = true;

	private int alphaCountMax = 7;
	private int alphaCount = 0;

	private Coroutine coroutine;

	private void Awake()
	{
		cancelButton.onClick.AddListener(OnClickCancel);
		deleteButton.onClick.AddListener(OnClickDelete);
		acceptButton.onClick.AddListener(OnClickAccept);
		for (int i = 0; i < alphabetButton.Length; i++)
		{
			var alphabet = (char)(i + 'A');
			alphabetButton[i].onClick.AddListener(() => OnClickAlphabet(alphabet));
		}
	}

	public void OnClickCancel()
	{
		nameText.text = "";
		alphaCount = 0;
		RestartCoroutine();
	}

	public void OnClickAlphabet(char alphabet)
	{
		if(alphaCount < alphaCountMax)
		{
			var str = new StringBuilder(nameText.text.Substring(0,alphaCount));
			nameText.text = str.Insert(alphaCount++, alphabet).ToString();
			if (alphaCount == alphaCountMax)
			{
				StopCoroutine(coroutine);
				coroutine = null;
				return;
			}
			RestartCoroutine();
		}
	}

	public void OnClickDelete()
	{
		if (alphaCount == 0)
			return;

		var str = new StringBuilder(nameText.text.Substring(0, alphaCount));
		nameText.text = str.Remove(str.Length - 1, 1).ToString();
		alphaCount--;
		RestartCoroutine();
	}

	public void OnClickAccept()
	{
		manager.Open(Windows.Start);
	}

	public override void Open()
	{
		base.Open();
		nameText.text = "";

		RestartCoroutine();
	}

	private IEnumerator CoCursorBlinking()
	{
		while(true)
		{
			CursorChanging();
			yield return new WaitForSeconds(0.3f);
			IsCursorOn = !IsCursorOn;
		}
	}

	private void CursorChanging()
	{
		var str = new StringBuilder(nameText.text);
		if (IsCursorOn)
		{ 
			nameText.text = str.Append('_').ToString();
		}
		else
		{
			nameText.text = str.Remove(str.Length - 1, 1).ToString();
		}
	}

	private void RestartCoroutine()
	{
		if (coroutine != null)
		{
			StopCoroutine(coroutine);
			coroutine = null;
		}

		IsCursorOn = true;
		coroutine = StartCoroutine(CoCursorBlinking());
	}
}
