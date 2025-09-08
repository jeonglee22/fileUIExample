using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
	public List<GenericWindow> windows;

	public Windows defaultWindow;

	public Windows CurrentWindow { get; private set; }

	private void Start()
	{
		foreach (var window in windows)
		{
			window.Init(this);
			window.gameObject.SetActive(false);
			// close 안쓰는 이유는 close에서 단순히 false말고 다른 일도 할 수 있기 때문에
		}

		CurrentWindow = defaultWindow;
		windows[(int)CurrentWindow].Open();
	}

	public void Open(Windows id)
	{
		windows[(int)CurrentWindow].Close();
		CurrentWindow = id;
		windows[(int)CurrentWindow].Open();
	}
}
