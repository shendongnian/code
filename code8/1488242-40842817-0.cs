    public class SceneController : SceneFader
    {
        internal void LoadScene(string sceneName) // name of the Scene to load
        {
            StartCoroutine(LoadSceneCoroutine(sceneName));
        }
        private IEnumerator LoadSceneCoroutine(string sceneName)
        {
            float lerpTimer = 0.0f;
            while (lerpTimer < base.lerpDuration)
            {
                lerpTimer += Time.deltaTime;
                SceneFadeOut(GetCamera(), Color.black, GetCamera().backgroundColor, lerpTimer / base.lerpDuration);
                yield return new WaitForEndOfFrame();
            }
            SceneFadeOut(GetCamera(), Color.black, GetCamera().backgroundColor, 1.0f);
            AsyncOperation m_AsyncOp = SceneManager.LoadSceneAsync(sceneName); // load the new scene
            yield return m_AsyncOp;
            lerpTimer = 0.0f;
            while (lerpTimer < base.lerpDuration)
            {
                lerpTimer += Time.deltaTime;
                SceneFadeIn(GetCamera(), Color.black, GetCamera().backgroundColor, lerpTimer / base.lerpDuration);
                yield return new WaitForEndOfFrame();
            }
            SceneFadeOut(GetCamera(), GetCamera().backgroundColor, Color.black, 1.0f);
        }
    }
