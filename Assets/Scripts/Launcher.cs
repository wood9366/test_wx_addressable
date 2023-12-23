using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviour
{
    public Button _bt_load_tex;
    public Button _bt_load_scene;
    public Image _img;

    private AsyncOperationHandle<Sprite> _h;

    void Start()
    {
        _bt_load_tex.onClick.AddListener(_on_click_load_tex);
        _bt_load_scene.onClick.AddListener(_on_click_load_scene);
    }

    void OnDestroy()
    {
        _bt_load_tex.onClick.RemoveListener(_on_click_load_tex);
        _bt_load_scene.onClick.RemoveListener(_on_click_load_scene);
        if (_h.IsValid())
			Addressables.Release(_h);
    }

    private void _on_click_load_tex()
    {
        if (_h.IsValid())
            return;

		StartCoroutine(_load_tex());
    }

    private IEnumerator _load_tex()
    {
        _h = Addressables.LoadAssetAsync<Sprite>("SampleTex");

        yield return _h;

        if (_h.Status == AsyncOperationStatus.Succeeded)
        {
            Debug.Log("load sample tex success");

            if (_img != null)
                _img.sprite = _h.Result;
		}
        else if (_h.Status == AsyncOperationStatus.Failed)
        {
            Debug.LogError($"load sample tex fail, {_h.OperationException}");
		}
    }

    private void _on_click_load_scene()
    {
        var h = Addressables.LoadSceneAsync("MainScene", LoadSceneMode.Single);

        h.Completed += x =>
        {
            if (h.Status == AsyncOperationStatus.Succeeded)
                Debug.Log("load main scene success");
            else if (h.Status == AsyncOperationStatus.Failed)
                Debug.LogError($"load main scene fail, {h.OperationException}");
        };
    }
}
