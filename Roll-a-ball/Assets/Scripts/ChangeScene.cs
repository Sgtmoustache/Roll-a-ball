using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	// Update is called once per frame
	public void ChangeToScene (int sceneToChangeTo) {
        SceneManager.LoadScene(sceneToChangeTo);
	}
    public void ExitApplication()
    {
       Application.Quit();
    }

}
