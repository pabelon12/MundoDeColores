using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarraCarga : MonoBehaviour
{
    [SerializeField] private Slider Barra;
    [SerializeField]private GameObject CagarEsena;
    public void contrlbarra(int sceneIndex)
    {
        CagarEsena.SetActive(true);
        StartCoroutine(LoadAsync(sceneIndex));
      
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!asyncOperation.isDone)
        {
            Debug.Log(asyncOperation.progress);
            Barra.value = asyncOperation.progress / 0.9f;
            yield return null;
        }
    }
}
