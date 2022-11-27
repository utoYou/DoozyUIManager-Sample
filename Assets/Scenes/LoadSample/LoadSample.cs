using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Doozy.Runtime.Reactor;
using Doozy.Runtime.UIManager.Components;

public class LoadSample : MonoBehaviour
{
  [SerializeField]
  private UIButton _loadButton;
  [SerializeField]
  private Progressor _progressor;

  private void Start()
  {
    _progressor.ResetToStartValues();
  }

  private IEnumerator LoadCoroutine()
  {
    var time = 3.0f;
    var progressTime = 0f;
    while (progressTime < time)
    {
      progressTime += Time.deltaTime;
      var progressRate = progressTime / time;
      _progressor.SetProgressAt(progressRate);
      yield return null;
    }
  }

  #region UnityEvent OnClick
  public void OnClickLoadButton()
  {
    Debug.LogError("OnClick");
    StartCoroutine(LoadCoroutine());
  }
  #endregion
}
