using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLogic : MonoBehaviour
{
    public Button playButton;

	void Start () {
		//Button btn = playButton.GetComponent<Button>();
		playButton.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		Application.LoadLevel("SampleScene");
	}
}
