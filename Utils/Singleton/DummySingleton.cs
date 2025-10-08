namespace Utils.Singleton
{
    public class DummySingleton : MonoSingleton<DummySingleton>
    {
        public void Yell()
        {
            UnityEngine.Debug.Log($"{gameObject.name} yells: AAAAHHHH!");
        }
    }
}