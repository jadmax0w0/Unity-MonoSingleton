using UnityEngine;

namespace Utils.Singleton
{
    public class DummySingletonTest : MonoBehaviour
    {
        public void TestYell()
        {
            DummySingleton.Instance.Yell();
        }
    }
}