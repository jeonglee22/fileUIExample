using UnityEngine;

public class PanelDrawingTest : MonoBehaviour
{
	public Transform panel;
	public Transform scrollView;

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			panel.SetAsFirstSibling();
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			scrollView.SetAsFirstSibling();
		}
	}
}
