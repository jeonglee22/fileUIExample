using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverWindow : GenericWindow
{
	public TextMeshProUGUI leftScore;
	public TextMeshProUGUI leftStat;
	public TextMeshProUGUI rightScore;
	public TextMeshProUGUI rightStat;
	public TextMeshProUGUI totalScore;

	public Button next;

	private float textLoadingInterval = 1f;

	private int textCount = 7;

	private Coroutine coroutine;

	private void Awake()
	{
		next.onClick.AddListener(OnClickNext);
		InitText();
	}

	public override void Open()
	{
		base.Open();
		coroutine = StartCoroutine(CoTextEffect());
	}

	public override void Close()
	{
		base.Close();
		if(coroutine != null)
			StopCoroutine(coroutine);
		InitText();
	}

	private void OnClickNext()
	{
		manager.Open(Windows.Start);
	}

	private IEnumerator CoTextEffect()
	{
		for (int i = 0; i < textCount; i++)
		{
			if (i < 3)
			{
				StringBuilder sbLeftScore = new StringBuilder(leftScore.text);
				StringBuilder sbLeftStat = new StringBuilder(leftStat.text);
				leftScore.text = sbLeftScore.Append($"{Random.Range(0, 100):D2}\n").ToString();
				leftStat.text = sbLeftStat.Append($"STAT{i:D2}\n").ToString();
			}
			else if (i < 6)
			{
				StringBuilder sbRightScore = new StringBuilder(rightScore.text);
				StringBuilder sbRightStat = new StringBuilder(rightStat.text);
				rightScore.text = sbRightScore.Append($"{Random.Range(0, 100):D2}\n").ToString();
				rightStat.text = sbRightStat.Append($"STAT{i:D2}\n").ToString();
			}
			else
			{
				totalScore.text = $"{Random.Range(0, 100000000):D8}";
			}
			yield return new WaitForSeconds(textLoadingInterval);
		}

		coroutine = null;
	}

	private void InitText()
	{
		leftScore.text = "";
		leftStat.text = "";
		rightScore.text = "";
		rightStat.text = "";
		totalScore.text = "";
	}
}
