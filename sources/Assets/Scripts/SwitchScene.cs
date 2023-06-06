using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToRegisterScene() 
    {
        SceneManager.LoadScene("RegisterScene");
    }

    public void ToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ToMeshingScene()
    {
        SceneManager.LoadScene("Meshing");
    }
}
